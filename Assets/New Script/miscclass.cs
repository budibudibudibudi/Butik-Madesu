using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class",menuName = "Item/misc")]
public class miscclass : itemclass
{
    public override itemclass getitem(){return this;}
    public override toolclass gettool(){return null;}
    public override miscclass getmisc(){return this;}
    public override ConsumeableClass getconsumeable(){return null;}
}
