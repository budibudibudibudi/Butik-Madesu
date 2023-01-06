using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FeatureManager : MonoBehaviour
{
    public List<Feature> features;
    public int currentfeature;


    void LoadFeatures()
    {
        features = new List<Feature>();
        features.Add(new Feature("ekspresi",gameObject.transform.Find("ekspresi").GetComponent<SpriteRenderer>()));
    }
    void SaveFeatures()
    {
        
    }

    public void setcurrent(int index)
    {
        if(features == null)
            return;
        
        currentfeature = index;
    }
}
[System.Serializable]
public class Feature
{
    public string ID;
    public int currentindex;
    public Sprite[] choices;
    public SpriteRenderer renderer;

    public Feature(string id,SpriteRenderer rend)
    {
        ID = id;
        renderer = rend;
        UpdateFeature();
    }

    public void UpdateFeature()
    {
        choices = Resources.LoadAll<Sprite>("aset2d/"+ID);
        if(choices == null || renderer == null)
            return;

        if(currentindex <0)
            currentindex = choices.Length -1;
        if(currentindex>=choices.Length)
            currentindex = 0;

        renderer.sprite = choices[currentindex];
    }
}