using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuMain : MonoBehaviour {

    public GameObject LeaderBoard;
    // Use this for initialization
    public void Play()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play");
    }
    public void LeaderBoards()
    {
        LeaderBoard.SetActive(true);
        Debug.Log("LeaderBoards");
    }
    public void Back()
    {
        LeaderBoard.SetActive(false);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
