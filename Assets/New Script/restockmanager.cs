using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restockmanager : MonoBehaviour
{
    public itemclass itemtoadd;
    public itemclass removeitem;
    public slotclass [] misc;

    public slotclass [] startingitem;
    public GameObject slotholder;
    public GameObject [] slots;
    public GameObject [] prevbtn;


    public void OnEnable()
    {
        slots = new GameObject[slotholder.transform.childCount];
        prevbtn = new GameObject[slotholder.transform.childCount];
        misc = new slotclass[slots.Length];

        for (int i = 0;i<misc.Length;i++)
            misc[i] = new slotclass();
        
        
        for (int i = 0;i<startingitem.Length;i++)
        {
            misc[i] = startingitem[i];
            //PlayerPrefs.SetInt(misc[i].getitem().name,misc[i].stock);  
        }

        for (int i = 0;i<slotholder.transform.childCount;i++)
            slots[i] = slotholder.transform.GetChild(i).gameObject;
            
        for (int i = 0;i<slotholder.transform.childCount;i++)   
            prevbtn[i] = slotholder.transform.GetChild(i).transform.GetChild(3).gameObject;

        foreach (var item in prevbtn)
        {
            item.SetActive(false);
        }
        FindObjectOfType<keranjangscript>().afterrestock();
        refreshUI();
        //add(itemtoadd,10);
        //removeitem = misc[0].getitem();
        //remove(removeitem);
    }

    void Update()
    {

        for (int i = 0;i<slots.Length;i++)
        {
            if(slots[i].transform.GetChild(0).GetComponent<Image>().sprite == null)
                slots[i].transform.GetChild(0).GetComponent<Button>().interactable = false;
        }    
    }

    public void refreshUI()
    {
        for (int i = 0;i<slots.Length;i++)
        {
            try
            {
                slots[i].transform.GetChild(1).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(1).GetComponent<Image>().color = new Color(255,255,255,255);
                slots[i].transform.GetChild(1).GetComponent<Image>().sprite = misc[i].getitem().itemicon;
                slots[i].transform.GetChild(5).GetComponent<Text>().text = misc[i].getitem().subsname;
                slots[i].transform.GetChild(6).GetComponent<Text>().text = "Harga : "+misc[i].getitem().hargarestock.ToString();
                
            }
            catch
            {
                slots[i].transform.GetChild(1).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(1).GetComponent<Image>().color = new Color(0,0,0,0);
                slots[i].transform.GetChild(1).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(5).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(6).GetComponent<Text>().text = "";
            }
        }
    }
}
