using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionmenuscript : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }
    public void mute()
    {
        AudioListener.volume = 0;
        GameObject g =this.gameObject;
        g.transform.GetChild(0).gameObject.SetActive(true);
        
    }

    public void unmute()
    {
        AudioListener.volume = 1;
        GameObject g =this.gameObject;
        g.transform.GetChild(0).gameObject.SetActive(false);
    }
}
