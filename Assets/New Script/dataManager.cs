using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;

public class dataManager : MonoBehaviour
{
    private string savePath;
    public static dataManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void SaveData(slotclass[] topi,slotclass[] baju,slotclass[] sabuk,slotclass[] celana,slotclass[] sepatu,int day,int uangdidompet)
    {
        savePath = Application.persistentDataPath + "/save_data.json";
        // Create a new container class to hold the string and integer values
        DataContainer data = new DataContainer {topi = topi,baju = baju,sabuk = sabuk,celana = celana,sepatu = sepatu,day = day,uangdidompet = uangdidompet};

        // Convert the container class to a JSON string
        string json = JsonUtility.ToJson(data);

        // Write the JSON string to a file
        File.WriteAllText(savePath, json);
    }

    public void loaddata()
    {
        savePath = Application.persistentDataPath + "/save_data.json";
        if (File.Exists(savePath))
        {
            // Read the JSON string from the file
            string json = File.ReadAllText(savePath);

            // Convert the JSON string back to the container class
            DataContainer data = JsonUtility.FromJson<DataContainer>(json);
            //load disini
            gamemanagerscript.instance.inven[0].misc = data.topi;
            gamemanagerscript.instance.inven[1].misc = data.baju;
            gamemanagerscript.instance.inven[2].misc = data.sabuk;
            gamemanagerscript.instance.inven[3].misc = data.celana;
            gamemanagerscript.instance.inven[4].misc = data.sepatu;
            gamemanagerscript.instance.day = data.day;
            gamemanagerscript.instance.uangdidompet = data.uangdidompet;
            foreach (var item in gamemanagerscript.instance.inven)
            {
                item.refreshUI();
            }
        }
        else
        {
            Debug.LogError("Save file not found at " + savePath);
        }
    }

}

[System.Serializable]
public class DataContainer
{
    public int uangdidompet;
    public int day;
    public slotclass[]topi;
    public slotclass[] baju;
    public slotclass[] sabuk;
    public slotclass[] celana;
    public slotclass[] sepatu;
}