using System;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;

namespace Src.Save
{
    public class SaveSystem
    {
        private PlayerData _data;
        private static SaveSystem _instance;

        public static SaveSystem Instance => _instance ??= new SaveSystem();

        [DllImport("__Internal")]
        private static extern void SaveExtern(string data);
        
        [DllImport("__Internal")]
        private static extern void LoadExtern();

        private SaveSystem()
        {
#if UNITY_WEBGL
            LoadExtern();      
#endif
        }

        public void SaveMoney(int amount)
        {
            if (amount >= 0)
            {
                _data.AddMoney(amount);
                Save();
            }
        }

        public int GetMoney()
        {
            return _data.Money;
        }

        public void SaveBuilding(int id, int level)
        {
            _data.AddBuilding(id, level);
            Save();
        }
        
        public int GetBuildingLevel(int id)
        {
            return _data.GetBuildingLevelById(id);
        }

        private void Save()
        {
            string json = JsonConvert.SerializeObject(_data);
#if UNITY_WEBGL
            SaveExtern(json);      
#endif
        }

        public void SetPlayerData(string value)
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(value);

            _data = playerData ?? new PlayerData();
        }
    }
}