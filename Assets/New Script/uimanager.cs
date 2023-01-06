using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uimanager : MonoBehaviour
{
    public GameObject[] tab;
    public int currindex = 0;
    public void gantitab(int index)
    {
        tab[currindex].SetActive(false);
        currindex = index;
        tab[currindex].SetActive(true);
      //  FindObjectOfType<headchose>().restok();
    }
}
