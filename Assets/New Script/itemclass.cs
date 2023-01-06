using UnityEngine;
using System.Collections;

public abstract class itemclass : ScriptableObject
{
    public string name;
    public string subsname;
    public Sprite itemicon;
    public bool isstackable = true;
    public int hargarestock;
    public int hargajual;
    public int index;

    public abstract itemclass getitem();
    public abstract toolclass gettool();
    public abstract miscclass getmisc();
    public abstract ConsumeableClass getconsumeable();
}
