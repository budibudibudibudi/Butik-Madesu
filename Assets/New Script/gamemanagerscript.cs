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

    private void Awake() {
        hari.SetActive(true);
        daytext.text = day.ToString();
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Quest.isactive)
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

    public void kerestok()
    {
        
    }
}
