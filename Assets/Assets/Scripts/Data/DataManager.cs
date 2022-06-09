using UnityEngine;

namespace Idle
{
    public class DataManager : MonoBehaviour
    {
        //Components
        static DataSaver dataSaver;

        public static Data data;
        public static UpgradeData upgradeData;

        private void Awake()
        {
            Init();
        }

        void Init()
        {
            //Create an instance of classes
            data = new Data();
            upgradeData = new UpgradeData();

            //Cached component from our Gameobject
            dataSaver = GetComponent<DataSaver>();

            LoadData();

            //We make the first launch, and give the starter kit
            if (!data.isFirstStartComplete)
            {
                data.isFirstStartComplete = true;

                data.Money = 100;
                data.MoneyByClick = 1;

                SaveData();
            }

        }

        //Static save method, can be called from any class "DataManager.SaveData();"
        public static void SaveData()
        {
            object[] obj = new object[2]; // Create a local variable for an array of objects
            //register the objects we need
            obj[0] = data;
            obj[1] = upgradeData;

            dataSaver.Save(obj); //Save to DataSaver
        }

        //Static load method, can be called from any class "DataManager.LoadData();"
        public static void LoadData()
        {
            object[] obj = dataSaver.Load();  //Get the data array from the file
            //We assign the objects we need
            if (obj != null)
            {
                data = obj[0] as Data;
                upgradeData = obj[1] as UpgradeData;
            }

        }

    }

}
