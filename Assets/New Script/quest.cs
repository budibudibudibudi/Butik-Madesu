using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//quest script
[System.Serializable]
public class quest
{
    public bool isactive;

    public string title;
    
    [TextArea(3,10)]
    public string description;
    public int reputasi;
    public int uang;
}