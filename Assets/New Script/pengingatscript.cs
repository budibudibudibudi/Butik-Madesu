using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pengingatscript : MonoBehaviour
{
    public GameObject textbox;
bool isopen = false;
    public void openintruksi()
    {
        if(!isopen)
        {
            textbox.SetActive(true);
            isopen = true;
        }
        else
        {
            isopen = false;
            textbox.SetActive(false);
        }
        textbox.transform.GetChild(0).GetComponent<Text>().text = FindObjectOfType<gamemanagerscript>().Quest.title + ", " +FindObjectOfType<gamemanagerscript>().Quest.description;
    }
}
