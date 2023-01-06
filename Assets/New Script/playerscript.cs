using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public GameObject canvas;
    public GameObject butik;

    private void Awake()
    {
        butik = GameObject.Find("butik");
    }
    public void takeorder()
    {
        canvas.SetActive(false);
        butik.SetActive(true);
    }
}
