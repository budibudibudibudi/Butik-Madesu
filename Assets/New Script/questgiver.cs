using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questgiver : MonoBehaviour
{
    public quest[] Quest;
    public gamemanagerscript gms;
    public GameObject textbox;
    string story;
    int rand;
    private void Awake() {
        gms = GameObject.Find("tempatscript").GetComponent<gamemanagerscript>();
        textbox = GameObject.Find("textbox");
        rand = Random.Range(0,2);
        textbox.transform.GetChild(0).GetComponent<Text>().text = Quest[rand].title;
        story = Quest[rand].description;
		StartCoroutine(PlayText());
    }

    public void acceptquest()
    {
        Quest[rand].isactive = true;
        textbox.SetActive(false);
        gms.Quest = Quest[rand];
        FindObjectOfType<spawnplayer>().spawned = false;
        this.gameObject.SetActive(false);
    }
	IEnumerator PlayText()
	{
		foreach (char c in story) 
		{
            textbox.transform.GetChild(1).GetComponent<Text>().text+=c;
			yield return new WaitForSeconds (0.01f);
		}
	}

}