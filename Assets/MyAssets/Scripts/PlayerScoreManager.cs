using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class PlayerScoreManager : MonoBehaviour {
    public GameObject PlayerEntry;
    int LastChangeCounter;
    ScoreBoard scoreBoard;
	// Use this for initialization
	void Start () {
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
        //LastChangeCounter = scoreBoard.GetChangeCounter();
        
	}

    

    // Update is called once per frame
    void Update ()
    {
        if(scoreBoard.GetChangeCounter()==LastChangeCounter)
        {
            return;
        }

        while(this.transform.childCount>0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] names = scoreBoard.GetPlayerNames("Score");

        foreach (string name in names)
        {
            GameObject temp = (GameObject)Instantiate(PlayerEntry);
            temp.transform.SetParent(this.transform);

            temp.transform.Find("Name").GetComponent<Text>().text = name;
            temp.transform.Find("Score").GetComponent<Text>().text = scoreBoard.GetScore(name, "Score").ToString();
        }
        LastChangeCounter = scoreBoard.GetChangeCounter();
    }
}
