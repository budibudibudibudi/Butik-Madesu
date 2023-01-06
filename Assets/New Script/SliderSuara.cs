using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSuara : MonoBehaviour
{
    [SerializeField] Slider Volumeslider;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        else
        {
            Load();
        }
    }

   public void changeVolume() {
       AudioListener.volume = Volumeslider.value;
       Save();
   }

    public void Load(){
        Volumeslider.value = PlayerPrefs.GetFloat("musicVolume");
    }

   public void Save(){
       PlayerPrefs.SetFloat("musicVolume", Volumeslider.value);
   }
}
