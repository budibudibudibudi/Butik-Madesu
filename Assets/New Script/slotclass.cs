using System.Collections;
using UnityEngine;

[System.Serializable]
public class slotclass
{
    [SerializeField]private itemclass item;
    public int stock;
    public int index;
    public slotclass()
    {
        item = null;
        stock = 0;
    }

    public slotclass(itemclass _item,int _stock)
    {
        item = _item;
        stock = _stock;
    }

    public void Clear()
    {
        this.item = null;
        this.stock = 0;
    }

    public itemclass getitem(){return item;}
    public int Getstock(){return stock;}
    public void addstock(int _stock){stock += _stock;}
    public void subsstock(int _stock){stock -= _stock;}
    public void additem(itemclass item,int stock)
    {
        this.item = item;
        this.stock = stock;
    }
}
