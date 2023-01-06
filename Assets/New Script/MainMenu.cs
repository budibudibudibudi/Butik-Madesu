using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int indexer = 0;
    public GameObject [] panel;
    public void Playgame()
    {
        SceneManager.LoadScene("game1");
    }

    public void mainmenupanel(int index)
    {
        panel[indexer].SetActive(false);
        indexer = index;
        panel[indexer].SetActive(true);
    }

    public void Quitgame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
