using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class",menuName = "Item/consumeable")]
public class ConsumeableClass : itemclass
{
    public float healthadded;

    public override itemclass getitem(){return this;}
    public override toolclass gettool(){return null;}
    public override miscclass getmisc(){return null;}
    public override ConsumeableClass getconsumeable(){return this;}
}
