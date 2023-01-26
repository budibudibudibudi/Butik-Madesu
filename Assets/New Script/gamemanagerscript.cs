using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class gamemanagerscript : MonoBehaviour
{
    public GameObject butik;
    public GameObject game;
    public GameObject restock;
    public GameObject kertaspengingat;
    public GameObject hari;
    public GameObject resultpanel;

    public quest Quest;

    public Text[] result;
    public Text Title;
    public Text deskripsi;
    public Text daytext;

    public int tip;
    public int uangdidompet = 0;
    public int pendapatanhariini = 0;
    public int day = 1;


    public inventorimanager[] inven = new inventorimanager[5];

    public static gamemanagerscript instance;

    private void Awake() {

        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        bool gameStart = PlayerPrefs.GetInt("New Game") == 0 ? true : false;
        if(gameStart)
        {
            foreach (var item in inven)
            {
                item.starter();
            }
        }
        else
        {
            foreach (var item in inven)
            {
                item.kosongan();
            }
            dataManager.instance.loaddata();
        }
        daytext.text = day.ToString();
        hari.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Quest.isactive)
        {
            butik.SetActive(true);
            game.SetActive(false);
            FindObjectOfType<headchose>().circle.SetActive(false);
        }
        else
        {
            butik.SetActive(false);
            game.SetActive(true);
        }
        
    }

    public void nextday()
    {
        resultpanel.SetActive(true);
        FindObjectOfType<spawnplayer>().endgame = true;
        result[2].text = day.ToString();
        result[0].text = "132";
        day++;
        hari.SetActive(false);
    }

    public void continueday()
    {
        resultpanel.SetActive(false);
        if(day == 5||day == 8||day == 11)
        {
            FindObjectOfType<spawnplayer>().maxspawn++;
        }
        FindObjectOfType<spawnplayer>().Awake();
    }

    public void pengingat(bool isopen)
    {
        kertaspengingat.SetActive(isopen);
        if(Quest.isactive)
        {
            Title.text = Quest.title;
            deskripsi.text = Quest.description;
        }
        else
        {
            Title.text = "";
            deskripsi.text ="";

        }
    }

    public void save()
    {
        dataManager.instance.SaveData(inven[0].misc, inven[1].misc, inven[2].misc, inven[3].misc, inven[4].misc, day, uangdidompet);
    }
    public void load()
    {
        dataManager.instance.loaddata();
    }
}
