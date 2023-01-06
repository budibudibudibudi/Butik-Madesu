using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class headchose : MonoBehaviour
{
    public inventorimanager[] im;
    public GameObject [] headslots;
    public GameObject headholder;
    public slotclass [] heads;
    
    public int headindex;
    public int pendapatan;
    gamemanagerscript gms;
    public GameObject circle;
    storage s;

    // Start is called before the first frame update
    void Start()
    {
        gms = FindObjectOfType<gamemanagerscript>();
        headslots = new GameObject[headholder.transform.childCount];
        heads = new slotclass[headslots.Length];
        for (int i = 0;i<heads.Length;i++)
            heads[i] = new slotclass();
        for (int i = 0;i<headholder.transform.childCount;i++)
            headslots[i] = headholder.transform.GetChild(i).gameObject;

    }

    private void OnEnable() {
        Debug.Log("enable");
    }

    public void restok(int index) {
        s = FindObjectOfType<storage>();
        foreach (var item in FindObjectOfType<uimanager>().tab)
        {
            item.SetActive(true);
        }

        im[s.penyimpanan[index].index].add(s.penyimpanan[index].getitem(),s.penyimpanan[index].Getstock());

        /*
        */
    }

    public IEnumerator backtonormal()
    {
        yield return new WaitForSeconds(1);
        
        foreach (var item in FindObjectOfType<uimanager>().tab)
        {
            item.SetActive(false);
        }
        FindObjectOfType<uimanager>().tab[0].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        headindex = FindObjectOfType<uimanager>().currindex;
    }
    public void chosed(int index)
    {
        onequip(im[headindex].misc[index].getitem());     
    }
    public void refreshhead()
    {
        
        for (int i = 0;i<headslots.Length;i++)
        {
            try
            {
                headslots[i].GetComponent<SpriteRenderer>().sprite = heads[i].getitem().itemicon;
            }
            catch
            {
                headslots[i].GetComponent<SpriteRenderer>().sprite = null;
            }
        }
        
    }

    public void onequip(itemclass item)
    {
        
        if(heads[headindex].getitem() == null)
        {
            heads[headindex].additem(item,1);
            im[headindex].remove(item);
            refreshhead();
            im[headindex].refreshUI();
        }
        
        else
        {
            if(item == heads[headindex].getitem())
                return;
            else
            {
                im[headindex].add(heads[headindex].getitem(),1);
                heads[headindex].Clear();
                refreshhead();
                im[headindex].refreshUI();
            }
        }
    }
    public void finalanswer()
    {
        int iscorrect = 0;
        for (int i = 0; i < heads.Length; i++)
        {
            if(this.heads[i].getitem() == null)
                Debug.Log("null"+i);
            else
            {
                if(this.heads[i].getitem().name == FindObjectOfType<gamemanagerscript>().Quest.title)
                    iscorrect++;
                else
                {
                    iscorrect--;
                    Debug.Log(iscorrect);
                }
                pendapatan += heads[i].getitem().hargajual;
                Debug.Log("pendapatan = "+pendapatan);
            }

        }
        if(iscorrect>2)
            gms.tip = 30;
        else if(iscorrect==1)
            gms.tip = 20;
        else if(iscorrect<=0)
            gms.tip = 0;
        pendapatan+=gms.tip;
        gms.uangdidompet += pendapatan;
        gms.pendapatanhariini += pendapatan;
        PlayerPrefs.SetInt("koin",gms.uangdidompet);
        circle.SetActive(true);
        circle.transform.Find("Canvas/pendapatan").GetComponent<Text>().text = ("$ "+pendapatan);
        FindObjectOfType<spawnplayer>().Awake();
        foreach (var item in heads)
        {
            item.Clear();
        }
        gms.Quest.isactive = false;
        gms.butik.SetActive(false);
        gms.game.SetActive(true);
    }
}
