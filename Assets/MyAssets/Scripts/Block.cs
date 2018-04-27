using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {
    public  Sprite              ToChange;
    private SpriteRenderer      OldSprite;
    public  PlayerController    Script;
    public GameObject GameOver;
    public GameObject Level;
    //private SpriteRenderer temp;
    //private SpriteRenderer test;
    //private GameObject[] blocks;
    private void Start()
    {
        OldSprite = GetComponent<SpriteRenderer>();
       
    }

    private void Update()
    {
        if(Script.GetCounter()>=28)
        {
            Time.timeScale = 0f;
            Level.SetActive(false);
            GameOver.SetActive(true);
        }
        //blocks = GameObject.FindGameObjectsWithTag("Block");
        //foreach (GameObject b in blocks)
        //{
        //    temp = GetComponent<SpriteRenderer>();
        //    if (temp.sprite != ToChange)
        //    {
        //        Debug.LogWarning("Almost done !");
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D Collision){

		if (Collision.gameObject.CompareTag("Player"))
        {
            if(OldSprite.sprite != ToChange)
            {
                OldSprite.sprite = ToChange;
                Script.AddPoints(25);
                Script.AddCounter(1);
            }			
		}
        
    }
}
