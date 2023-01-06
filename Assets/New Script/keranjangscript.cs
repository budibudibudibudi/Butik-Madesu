using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keranjangscript : MonoBehaviour
{
    public restockmanager[] rm;
    public slotclass [] heads;
    public int headindex;

    AudioSource audio;
    public AudioClip[] clips;

    public int [] jumlahstok;

    private void Start() {
        PlayerPrefs.DeleteAll();
        audio = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {   
        headindex = FindObjectOfType<uimanagerrestock>().currindex;
    }
    public void chosed(int index)
    {
        onequip(rm[headindex].misc[index].getitem(),1);     
        Debug.Log(rm[headindex].misc[index].getitem().name);
        jumlahstok[index]++;
        rm[headindex].slots[index].transform.Find("bar jumlah/Text").GetComponent<Text>().text = jumlahstok[index].ToString();
        rm[headindex].prevbtn[index].SetActive(true);
        rm[headindex].refreshUI();
    }

    public bool onequip(itemclass item,int quantity)
    {
        //misc.Add(item);
        slotclass slot = Contains(item);
        if (slot != null)
            if(slot.getitem().isstackable)
                slot.addstock(quantity);
            else
            {
                for (int i = 0; i < heads.Length; i++)
                {
                    if (heads[i].getitem() == null)
                    {
                        heads[i].additem(item, quantity);
                        break;
                    }
                }
            }
        else
        {
            for (int i = 0; i < heads.Length; i++)
            {
                if (heads[i].getitem() == null)
                {
                    heads[i].additem(item, quantity);
                    break;
                }
            }
        }
        rm[headindex].refreshUI();
        return true;
    }

    public void undo(int index)
    {
        unbuy(rm[headindex].misc[index].getitem());
        if(jumlahstok[index] < 0)
            jumlahstok[index] = 0;
        jumlahstok[index]--;
        rm[headindex].slots[index].transform.Find("bar jumlah/Text").GetComponent<Text>().text = jumlahstok[index].ToString();
        rm[headindex].refreshUI();
    }

    public bool unbuy(itemclass item)
    {
        for (int i = 0; i < heads.Length; i++)
        {
            if(heads[i].getitem() == item)
            {
                if(heads[i].Getstock()>1)
                    heads[i].subsstock(1);
                else
                {
                    rm[headindex].prevbtn[i].SetActive(false);
                    heads[i].Clear();
                }
                rm[headindex].refreshUI();
            }
            else
            {
               return false;
            }
        }
        rm[headindex].refreshUI();
        return true;
    }
    public slotclass Contains(itemclass item)
    {
        for(int i = 0; i < heads.Length; i++)
        {
            if(heads[i].getitem() == item)
                return heads[i];
        }
        return null;
    }
    public void finalanswer()
    {
        for (int i = 0; i < heads.Length; i++)
        {
            if(this.heads[i].getitem() == null)
                Debug.Log("bagan "+i+" kosong");
            else
            {
                FindObjectOfType<storage>().add(heads[i].getitem(),heads[i].Getstock());
                Debug.Log(heads[i].Getstock());
                heads[i].Clear();
                refreshkeranjang();
            }
        }
    }

    public void afterrestock()
    {
        heads = new slotclass[rm[headindex].slots.Length];
        jumlahstok = new int[rm[headindex].slots.Length];
        for (int i = 0; i < heads.Length; i++)
        {
            heads[i] = new slotclass();
        }
        
    }

    public void refreshkeranjang()
    {
        for (int i = 0; i < heads.Length; i++)
        {
            try
            {
                rm[headindex].slots[i].transform.Find("bar jumlah/Text").GetComponent<Text>().text = heads[i].Getstock().ToString();
                //penentu.transform.GetChild(3).transform.GetChild(heads[i].getitem().index).GetComponent<Text>().text = heads[i].getitem().subsname + "  Dengan jumlah   "+heads[i].Getstock();

            }
            catch
            {
                rm[headindex].slots[i].transform.Find("bar jumlah/Text").GetComponent<Text>().text = "0";
                //penentu.transform.GetChild(3).transform.GetChild(heads[i].getitem().index).GetComponent<Text>().text = "";
                
            }
        }
    }

    public void clearallkeranjang()
    {
        foreach (var item in heads)
        {
            item.Clear();
        }
    }
}
