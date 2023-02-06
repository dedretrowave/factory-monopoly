using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using UnityEngine;

namespace Src.Save
{
    public class SaveSystem : MonoBehaviour
    {
        private PlayerData _data;
        private static SaveSystem _instance;

        public static SaveSystem Instance => _instance;

        [DllImport("__Internal")]
        private static extern void SaveExtern(string data);

        private void SaveInternal(string data)
        {
            File.WriteAllText($"{Application.persistentDataPath}/save.dat", data);
        }
        
        [DllImport("__Internal")]
        private static extern void LoadExtern();

        private void LoadInternal()
        {
            if (!File.Exists($"{Application.persistentDataPath}/save.dat"))
            {
                File.Create($"{Application.persistentDataPath}/save.dat");
            }
            
            string serializedData = File.ReadAllText($"{Application.persistentDataPath}/save.dat");

            PlayerData deserializedData = JsonConvert.DeserializeObject<PlayerData>(serializedData);

            _data = deserializedData ?? new PlayerData();
        }

        private void Awake()
        {
            _instance = this;
#if !UNITY_EDITOR && UNITY_WEBGL
            LoadExtern();      
#else
            LoadInternal();
#endif
        }

        public bool GetIsStartingCollected()
        {
            return _data.IsStartingMoneyCollected;
        }

        public void SaveMoney(int amount)
        {
            _data.IsStartingMoneyCollected = true;
            
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
#if !UNITY_EDITOR && UNITY_WEBGL
            SaveExtern(json);
#else
            SaveInternal(json);
#endif
        }

        public void SetPlayerData(string value)
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(value);

            _data = playerData ?? new PlayerData();
        }
    }
}