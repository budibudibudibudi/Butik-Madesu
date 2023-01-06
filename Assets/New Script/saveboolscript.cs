using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveboolscript : MonoBehaviour
{
    
    int booltoint(bool val)
    {
        if(val)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    bool inttobool(int val)
    {
        if(val != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
