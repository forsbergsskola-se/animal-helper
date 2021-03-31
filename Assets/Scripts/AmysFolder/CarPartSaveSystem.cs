using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class CarPartSaveSystem
{
    public static void SavePlayer(CarPartController controller) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.derby";
        FileStream stream = new FileStream(path, FileMode.Create);

        CarPartData data = new CarPartData(controller);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static CarPartData LoadCarParts()
    {
        string path = Application.persistentDataPath + "/player.derby";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CarPartData data = formatter.Deserialize(stream) as CarPartData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save File not found " + path);
            return null;
        }
    }
}
