using System;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;

namespace Src.Save
{
    public class SaveSystem
    {
        private PlayerData _data;
        private static SaveSystem _instance;

        public static SaveSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SaveSystem();
                }

                return _instance;
            }
        }

        private SaveSystem()
        {
            Load();
        }
        
        [DllImport("__Internal")]
        private static extern void SaveExtern(string data);
        
        [DllImport("__Internal")]
        private static extern string LoadExtern();

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
            foreach (var playerDataBuildingsLevel in _data.BuildingsLevels)
            {
                Debug.Log($"{playerDataBuildingsLevel.Id} : {playerDataBuildingsLevel.Level}");
            }
            Save();
        }
        
        public int GetBuildingLevel(int id)
        {
            return _data.GetBuildingLevelById(id);
        }

        private void Save()
        {
            string json = JsonConvert.SerializeObject(_data);
            SaveExtern(json);
        }

        private void Load()
        {
            SetPlayerData(LoadExtern());
        }

        private void SetPlayerData(string value)
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(value);

            _data = playerData ?? new PlayerData();
        }
    }
}