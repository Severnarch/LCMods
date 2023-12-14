# LCMods
> A root repository for all of my Lethal Company mods

This repository contains every single one of my Lethal Company mods' sources. Each folder is a separate mod, and each folder has a README.md inside of it to summarise the mod as well as list its purpose and usage.

## Applications Used
To make these mods, I use two applications. First is Visual Studio 2022 which is the code editor with .NET support, and the second is ILSpy to read the source code of Lethal Company. In addition to these applications, I have a helper Python script `create.py` which quickly makes a template for the mod using `bepinex5plugin` with the correct framework and Unity version alongside a name input.

A small note on the `create.py` script, you will still have to manually add the references (which can be found in `Source References` below) through your own IDE.

## Source References
In case you want to modify or assist in these mods yourself, the references used in the source are `UnityEngine.CoreModule`, `Assembly-CSharp` (which contains Lethal Company source code), `BepInEx`, `0Harmony`, and `UnityEngine`. Each of these are DLL files which can be found in the Lethal Company folder in `Lethal Company_Data/Managed` (AssemblyCSharp, UnityEngine, UnityEngineCoreModule) and `BepInEx/core` (0Harmony, BepInEx). There are no additional references/dependencies unless stated in the mod folder's `README.md`