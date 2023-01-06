using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uimanagerrestock : MonoBehaviour
{
    [SerializeField] GameObject[] tab;
    public int currindex = 0;
    public GameObject restokpanel;
    public void realgantitab(int index)
    {
        FindObjectOfType<keranjangscript>().clearallkeranjang();
        tab[currindex].SetActive(false);
        currindex = index;
        tab[currindex].SetActive(true);
    }

    public void closerestok()
    {
        restokpanel.SetActive(true);
    }
}
