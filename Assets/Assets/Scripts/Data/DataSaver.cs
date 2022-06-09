using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

namespace Idle
{
    public class DataSaver : MonoBehaviour
    {
        //Output File Name
        public string fileName;

        //Method to save, accepts any types Save(int[]), Save(string[]), Save(SampleClass[])
        public void Save(object[] objects)
        {
            //Create a local instance of a binary formatter
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            //Open or create file
            using (FileStream fileStream = File.Open(Application.persistentDataPath + "/" + fileName + ".bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, objects); //We write our Objects to a file.
                fileStream.Close();  //Close the file
            }
        }
        //Method to load
        public object[] Load()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            //Check for file existence
            if (!File.Exists(Application.persistentDataPath + "/" + fileName + ".bin"))
                return null;

            using (FileStream fileStream = (File.Open(Application.persistentDataPath + "/" + fileName + ".bin", FileMode.Open)))
            {
                object[] obj = binaryFormatter.Deserialize(fileStream) as object[]; //Get the array of data from the file

                return obj; //We return them and load in DataManager
            }
        }

    }
}
