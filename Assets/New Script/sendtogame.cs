using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendtogame : MonoBehaviour
{
    private GameObject[] headslots;
    private slotclass[] heads;
    public GameObject headholder;
    // Start is called before the first frame update
    void Start()
    {
        headslots = new GameObject[headholder.transform.childCount];
        heads = new slotclass[headslots.Length];
    }

}
