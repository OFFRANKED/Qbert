using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;

public class ScoreBoard : MonoBehaviour {
    Dictionary<string, Dictionary<string, int>> NameScore;
    int ChangeCounter = 0;
    
	// Use this for initialization
	void Start ()
    {
        ReadFromFile();
        //Some testting stuff :->
        //SetScore("test1", "Score", 1000);
        //SetScore("test2", "Score", 100);
        //SetScore("test3", "Score", 10);
        //SetScore("test4", "Score", 1);
        //SetScore("test5", "Score", 10000);
    }
    private void ReadFromFile()
    {
        StreamReader reader = new StreamReader(@".\Assets\MyAssets\Scripts\Score.txt");

        string a = reader.ReadLine();
        while (a != null)
        {
            char[] delimiter = {':' };
            string[] fields = a.Split(delimiter);
            SetScore(fields[0], fields[1], Convert.ToInt32(fields[2]));

            a = reader.ReadLine();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void Init()
    {
        if (NameScore != null)
            return;

        NameScore = new Dictionary<string, Dictionary<string, int>>();
    }

    public int GetScore(string Name, string scoreType)
    {
        Init();

        if(NameScore.ContainsKey(Name) == false)
        {
            return 0;
        }

        if(NameScore[Name].ContainsKey(scoreType) == false)
        {
            return 0;
        }

        return NameScore[Name][scoreType];
    }
    public void SetScore(string Name, string ScoreType, int value)
    {
        Init();
        

        if(NameScore.ContainsKey(Name) == false)
        {
            NameScore[Name] = new Dictionary<string, int>();
        }
        NameScore[Name][ScoreType] = value;
        ChangeCounter++;
    }
    public void ChangeScore(string Name, string ScoreType, int amount)
    {
        Init();
        int CurrScore = GetScore(Name, ScoreType);
        SetScore(Name, ScoreType, CurrScore + amount);

    }
    public string[] GetPlayerNames()
    {
        Init();
        return NameScore.Keys.ToArray();
    }
    public string[] GetPlayerNames(string ShortScoreType)
    {
        Init();
        return NameScore.Keys.OrderByDescending(n => GetScore(n, ShortScoreType)).ToArray();
    }
    public int GetChangeCounter()
    {
        return ChangeCounter;
    }

}
