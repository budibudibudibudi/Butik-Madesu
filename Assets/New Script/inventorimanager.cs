using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventorimanager : MonoBehaviour
{
    public itemclass itemtoadd;
    public itemclass removeitem;
    public slotclass [] misc;

    public slotclass[] startingitem;
    public GameObject slotholder;
    public GameObject [] slots;



    public void Awake()
    {
        slots = new GameObject[slotholder.transform.childCount];
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

        
        refreshUI();
        //removeitem = misc[0].getitem();
        //remove(removeitem);
    }

    private void OnEnable() {
    }

    public void refreshUI()
    {
        for (int i = 0;i<slots.Length;i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(255,255,255,255);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = misc[i].getitem().itemicon;
                if(misc[i].getitem().isstackable)
                    slots[i].transform.Find("display item/stokbar/jumlahtext").GetComponent<Text>().text = misc[i].Getstock()+"";
                else
                    slots[i].transform.Find("display item/stokbar/jumlahtext").GetComponent<Text>().text = "";
                slots[i].transform.Find("display item/namebar/nametext").GetComponent<Text>().text = misc[i].getitem().subsname;
                
            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(0,0,0,0);
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.Find("display item/stokbar/jumlahtext").GetComponent<Text>().text = "";
                slots[i].transform.Find("display item/namebar/nametext").GetComponent<Text>().text = "";
            }
        }
    }

    public bool add(itemclass item,int quantity)
    {
        //misc.Add(item);
        slotclass slot = Contains(item);
        if (slot != null)
            if(slot.getitem().isstackable)
                slot.addstock(quantity);
            else
            {
                for (int i = 0; i < misc.Length; i++)
                {
                    if (misc[i].getitem() == null)
                    {
                        misc[i].additem(item, quantity);
                        break;
                    }
                }
            }
        else
        {
            for (int i = 0; i < misc.Length; i++)
            {
                if (misc[i].getitem() == null)
                {
                    misc[i].additem(item, quantity);
                    break;
                }
            }
        }
        refreshUI();
        return true;
    }
    
    public bool remove(itemclass item)
    {
        //misc.Remove(item);
        slotclass temp = Contains(item);
        if(temp != null)
        {
            if(temp.Getstock()>1)
                temp.subsstock(1);
            else
            {
                int slottoremove = 0;
                for(int i = 0;i < misc.Length; i++)
                {
                    if(misc[i].getitem() == item)
                    {
                        slottoremove = i;
                        break;
                    }
                }
                misc[slottoremove].Clear();
            }
        }
        else
        {
            return false;
        }
        refreshUI();
        return true;
    }

    public slotclass Contains(itemclass item)
    {
        for(int i = 0; i < misc.Length; i++)
        {
            if(misc[i].getitem() == item)
                return misc[i];
        }
        return null;
    }
    
}
