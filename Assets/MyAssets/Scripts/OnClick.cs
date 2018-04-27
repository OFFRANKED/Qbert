using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour {
    public InputField T_Name;
    public PlayerController Player;
    private string name;
    private string ScoreType;
    private int value;

    public void Submit()
    {
        name = T_Name.text;
        value = Player.GetPoints();
        ScoreType = "Score";
        //value = 900;
        // text = T_Name.GetComponent<Text>();
        WriteOnFile(name, ScoreType, value);
        StartCoroutine(wait());
        //Debug.Log(text);
    }
    void WriteOnFile(string _Name, string _ScoreType, int _Value)
    {
        StreamWriter writer = new StreamWriter(@".\Assets\MyAssets\Scripts\Score.txt", true);

        string output = _Name + ":" + _ScoreType + ":" + _Value;
        writer.WriteLine(output);
        writer.Close();
        Debug.LogWarning("Data Saved!\n");
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
