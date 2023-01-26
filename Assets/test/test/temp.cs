using UnityEngine;
using System.IO;

public class temp : MonoBehaviour
{
    private string savePath;
    public inventorimanager[] savemc;
    public inventorimanager[] mczero;
    public static temp instance;
    public int day;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        savePath = Application.persistentDataPath + "/data.json";
    }

    public void SaveData(slotclass[] type)
    {
        // Create a new container class to hold the string and integer values
        DataContainerTemp data = new DataContainerTemp { tempi = type};

        // Convert the container class to a JSON string
        string json = JsonUtility.ToJson(data);

        // Write the JSON string to a file
        File.WriteAllText(savePath, json);
    }

    public void loadint()
    {
        if (File.Exists(savePath))
        {
            // Read the JSON string from the file
            string json = File.ReadAllText(savePath);

            // Convert the JSON string back to the container class
            DataContainerTemp data = JsonUtility.FromJson<DataContainerTemp>(json);

            //savemc[0].type[0].stock = data.tempi[0].type[0].stock;
            mczero[0].startingitem = data.tempi;
        }
        else
        {
            Debug.LogError("Save file not found at " + savePath);
        }
    }

    public void adddata()
    {
        for (int i = 0; i < mczero.Length; i++)
        {
            SaveData(mczero[i].startingitem);
            //for (int j = 0; j < mczero[i].misc.Length; j++)
            //{

            //}
        }
    }
}

[System.Serializable]
public class DataContainerTemp
{
    public slotclass[] tempi;
}