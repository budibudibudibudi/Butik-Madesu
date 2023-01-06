using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storage : MonoBehaviour
{
    public slotclass [] penyimpanan;

    public slotclass [] temppenyimpanan;

    public GameObject butik;
    // Start is called before the first frame update
    void Start()
    {
        penyimpanan = new slotclass [99];
        for (int i = 0; i < penyimpanan.Length; i++)
        {
            penyimpanan[i] = new slotclass();
        }
        for (int i = 0; i < temppenyimpanan.Length; i++)
        {
            temppenyimpanan[i] = new slotclass();
        }
    }

    public bool add(itemclass item,int quantity)
    {
        //penyimpanan.Add(item);
        slotclass slot = Contains(item);
        if (slot != null)
            if(slot.getitem().isstackable)
                slot.addstock(quantity);
            else
            {
                for (int i = 0; i < penyimpanan.Length; i++)
                {
                    if (penyimpanan[i].getitem() == null)
                    {
                        penyimpanan[i].additem(item, quantity);
                        break;
                    }
                }
            }
        else
        {
            for (int i = 0; i < penyimpanan.Length; i++)
            {
                if (penyimpanan[i].getitem() == null)
                {
                    penyimpanan[i].additem(item, quantity);
                    break;
                }
            }
        }
        return true;
    }
    public slotclass Contains(itemclass item)
    {
        for(int i = 0; i < penyimpanan.Length; i++)
        {
            if(penyimpanan[i].getitem() == item)
                return penyimpanan[i];
        }
        return null;
    }

    public void openbutik()
    {
        butik.SetActive(true);
        for (int i = 0; i < penyimpanan.Length; i++)
        {
            try
            {
                penyimpanan[i].index = penyimpanan[i].getitem().index;FindObjectOfType<headchose>().restok(i);
            }
            catch
            {
                penyimpanan = new slotclass[i];
            }
        }

        StartCoroutine(FindObjectOfType<headchose>().backtonormal());
    }
}
