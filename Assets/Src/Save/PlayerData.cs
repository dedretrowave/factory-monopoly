using System;
using System.Collections.Generic;

namespace Src.Save
{
    [Serializable]
    public class BuildingLevel
    {
        public int Id;
        public int Level;

        public BuildingLevel(int id, int level)
        {
            Id = id;
            Level = level;
        }
    }
    
    public class PlayerData
    {
        public int Money = -1;
        public readonly List<BuildingLevel> BuildingsLevels = new();

        public void AddMoney(int amount)
        {
            if (amount >= 0)
            {
                Money = amount;
            }
        }

        public void AddBuilding(int id, int level)
        {
            BuildingLevel buildingLevel = new BuildingLevel(id, level);

            BuildingLevel buildingInArray = BuildingsLevels.Find(building => building.Id == id);

            if (buildingInArray != null)
            {
                buildingInArray.Level = level;
                return;
            }

            BuildingsLevels.Add(buildingLevel);
        }

        public int GetBuildingLevelById(int id)
        {
            BuildingLevel buildingInArray = BuildingsLevels.Find(building => building.Id == id);

            return buildingInArray != null ? buildingInArray.Level : 0;
        }
    }
}