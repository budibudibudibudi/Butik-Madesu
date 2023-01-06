using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class moviecontroller : MonoBehaviour
{
    public slotclass [] keranjang = new slotclass[2];
    public slotclass [] storage = new slotclass[2];
    temp t;
    private void Awake() {
        Debug.Log("awake");
    }
    public void Start() {
        t = FindObjectOfType<temp>();
        Debug.Log("start");
    }
    private void OnEnable() {
        Debug.Log("enable");
    }
    public void temp(itemclass item)
    {
        for (int i = 0; i < storage.Length; i++)
        {
            if(storage[i].getitem()!= item)
                continue;
            else
            {
                keranjang[i].additem(storage[i].getitem(),1);
            }
        }
    }
    
}
