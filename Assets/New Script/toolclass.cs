using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class",menuName = "Item/tool")]
public class toolclass : itemclass
{
    public ToolType toolType;

    public enum ToolType
    {
        wajah
    }
    public override itemclass getitem(){return this;}
    public override toolclass gettool(){return this;}
    public override miscclass getmisc(){return null;}
    public override ConsumeableClass getconsumeable(){return null;}
}
