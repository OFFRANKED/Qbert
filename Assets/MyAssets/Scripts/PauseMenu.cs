using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject Pause_Menu;
	
	// Update is called once per frame
	void Update () {
        InputKey();
	}
    private void InputKey()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_Menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnClickedBack()
    {
        Pause_Menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnClickedMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OnClickedExit()
    {
        Application.Quit();
    }
}
