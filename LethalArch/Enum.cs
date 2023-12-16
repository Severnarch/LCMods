using System;
using System.Collections.Generic;
using System.Text;

// MoonInformation Dictionary Information Reference (last updated v45)
//[Mod Print Message  ] Print Reference --------------------- Long Name ---------    Scene Name ---------
//[Message: LethalArch] ExperimentationLevel (SelectableLevel)(41 Experimentation on Level1Experimentation), 0
//[Message: LethalArch] AssuranceLevel (SelectableLevel)(220 Assurance on Level2Assurance), 1
//[Message: LethalArch] VowLevel (SelectableLevel)(56 Vow on Level3Vow), 2
//[Message: LethalArch] CompanyBuildingLevel (SelectableLevel)(71 Gordion on CompanyBuilding), 3
//[Message: LethalArch] MarchLevel (SelectableLevel)(61 March on Level4March), 4
//[Message: LethalArch] RendLevel (SelectableLevel)(85 Rend on Level5Rend), 5
//[Message: LethalArch] DineLevel (SelectableLevel)(7 Dine on Level6Dine), 6
//[Message: LethalArch] OffenseLevel (SelectableLevel)(21 Offense on Level7Offense), 7
//[Message: LethalArch] TitanLevel (SelectableLevel)(8 Titan on Level8Titan), 8

namespace LethalArch
{
    public class MoonLevel(
        int MoonID, 
        
        string LongName, string ShortName, string SceneName, string PrintReference
    )
    {
        public int MoonID = MoonID;

        public string LongName = LongName;
        public string ShortName = ShortName;
        public string SceneName = SceneName;
        public string PrintReference = PrintReference;
    }

    public class Enum
    {
        public static Dictionary<int, MoonLevel> MoonInformation = new()
        {
            {0, new(0,
                "41 Experimentation",
                "Experimentation",
                "Level1Experimentation",
                "ExperimentationLevel"
            ) },
            {1, new(1,
                "220 Assurance",
                "Assurance",
                "Level2Assurance",
                "AssuranceLevel"
            ) },
            {2, new(2,
                "56 Vow",
                "Vow",
                "Level3Vow",
                "VowLevel"
            ) },
            {3, new(3,
                "71 Gordion",
                "Company",
                "CompanyBuilding",
                "CompanyBuildingLevel"
            ) },
            {4, new(4,
                "61 March",
                "March",
                "Level4March",
                "MarchLevel"
            ) },
            {5, new(5,
                "85 Rend",
                "Rend",
                "Level5Rend",
                "RendLevel"
            ) },
            {6, new(6,
                "7 Dine",
                "Dine",
                "Level6Dine",
                "DineLevel"
            ) },
            {7, new(7,
                "21 Offense",
                "Offense",
                "Level7Offense",
                "OffenseLevel"
            ) },
            {8, new(8,
                "8 Titan",
                "Titan",
                "Level8Titan",
                "TitanLevel"
            ) },
        };
    }
}
