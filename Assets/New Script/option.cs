using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class option : MonoBehaviour
{
    bool ispaused = false;
    bool isopen = false;
    [SerializeField] GameObject panelpause;
    [SerializeField] Animator anim;
    [SerializeField] Button tomboloption; 

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isopen)
            {
                anim.SetBool("isopen",false);
                tomboloption.GetComponentInChildren<Text>().text = ">";
                isopen = false;

            }
            else
            {
                if(!ispaused)
                {
                    ispaused = true;
                    panelpause.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                    ispaused = false;
                    panelpause.SetActive(false);
                }

            }
        }
    }

    public void pausing()
    {
        if(!ispaused)
        {
            ispaused = true;
            panelpause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            ispaused = false;
            panelpause.SetActive(false);
        }
    }

    public void opsion()
    {
        if(!isopen)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("tutup option")||anim.GetCurrentAnimatorStateInfo(0).IsName("diem 0"))
            {
                anim.SetBool("isopen",true);
                tomboloption.GetComponentInChildren<Text>().text = "<";
                isopen = true;
            }
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("buka option"))
            {
                anim.SetBool("isopen",false);
                tomboloption.GetComponentInChildren<Text>().text = ">";
                isopen = false;
            }
        }
    }
}
