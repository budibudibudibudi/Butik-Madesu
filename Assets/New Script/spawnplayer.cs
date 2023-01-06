using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnplayer : MonoBehaviour
{
    public bool spawned = false;
    public bool endgame = false;
    public GameObject pelanggan;
    public Transform spawnpos;
    public int currentspawn = 0;
    public int maxspawn = 3;
    // Start is called before the first frame update
    public void Awake()
    {
        Invoke("spawnpelanggan",1);
    }
    public void spawnpelanggan()
    {
        if(!endgame)
        {
            if(!spawned)
            {
                Instantiate(pelanggan,spawnpos.position,spawnpos.rotation);
                spawned = true;
                currentspawn++;
                if(currentspawn == 3)
                {
                    endgame = true;
                }
            }
            else
            {
                Debug.Log("spawned");
            }
        }
        else
        {
            currentspawn = 0;
            CancelInvoke("spawnpelanggan");
            FindObjectOfType<gamemanagerscript>().nextday();
        }
    }
}
