import subprocess, threading, os

UnityVersion = "2022.3.9"
DotNetFramework = "netstandard2.1"

ModName:str        = input("Mod Name            -> ")
ModDescription:str = input("Mod Description     -> ")
ModVersion:str     = input("Mod Version (x.x.x) -> ")

if len(ModName) == 0: ModName = "UnnamedMod"
if len(ModVersion) == 0 or len(ModVersion.split(".")) != 3: ModVersion = "1.0.0"

command:str = "dotnet new bepinex5plugin -T %s -U %s -n %s"%(DotNetFramework, UnityVersion, ModName)
print("Creating mod template with name %s"%(ModName))
subprocess.run(command.split(" "))

basePluginScript = """
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace [ModName]
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class [ModName]Base : BaseUnityPlugin
    {
        private const string NAME = PluginInfo.PLUGIN_NAME;
        private const string VERSION = PluginInfo.PLUGIN_VERSION;
        private const string GUID = "io.github.severnarch.LCMods." + NAME;

        private readonly Harmony harmony = new Harmony(GUID);
        private [ModName]Base instance;
        private ManualLogSource logSource;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            logSource = BepInEx.Logging.Logger.CreateLogSource(NAME);
            logSource.LogMessage($"Preparing {NAME} v{VERSION}...");

            logSource.LogDebug($"Patching all {NAME} patches...");
            harmony.PatchAll(typeof([ModName]Base));
            logSource.LogDebug($"Patched all {NAME} patches!");

            logSource.LogMessage($"Prepared {NAME}!");
        }
    }
}
"""
csProjContent = """
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>[DotNetFramework]</TargetFramework>
    <AssemblyName>[ModName]</AssemblyName>
    <Description>[ModDescription]</Description>
    <Version>[ModVersion]</Version>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    <LangVersion>latest</LangVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="BepInEx.Analyzers" Version="1.*" PrivateAssets="all" />
    <PackageReference Include="BepInEx.Core" Version="5.*" />
    <PackageReference Include="BepInEx.PluginInfoProps" Version="1.*" />
    <PackageReference Include="UnityEngine.Modules" Version="[UnityVersion]" IncludeAssets="compile" />
  </ItemGroup>
  
  <ItemGroup Condition="'$(TargetFramework.TrimEnd(`0123456789`))' == 'net'">
    <PackageReference Include="Microsoft.NETFramework.ReferenceAssemblies" Version="1.0.2" PrivateAssets="all" />
  </ItemGroup>
</Project>

"""

def fillPlaceholders(content:str, **kwargs):
    for name in kwargs:
        content = content.replace(f"[{name}]", kwargs[name])
    return content

templatePluginLocation = "%s/Plugin.cs"%(ModName)
csProjLocation = "%s/%s.csproj"%(ModName,ModName)
print("Renaming Plugin.cs to %sBase.cs"%(ModName))
os.rename(templatePluginLocation, templatePluginLocation.replace("Plugin.cs","%sBase.cs"%(ModName)))
with open("%s/%sBase.cs"%(ModName,ModName),"w") as pcs:
	print("Modifying %sBase.cs content..."%(ModName))
	pcs.write(fillPlaceholders(basePluginScript, 
        ModName=ModName, ModVersion=ModVersion, ModDescription=ModDescription))
with open(csProjLocation,"w") as cpl:
    print("Modifying %s.csproj content..."%(ModName))
    cpl.write(fillPlaceholders(csProjContent, 
        ModName=ModName, ModVersion=ModVersion, ModDescription=ModDescription,
        DotNetFramework=DotNetFramework, UnityVersion=UnityVersion))