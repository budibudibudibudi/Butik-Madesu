using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class moviecontroller : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("New Game") == 1)
        {
            temp.instance.loadint();
        }
        else
            return;
    }
}
