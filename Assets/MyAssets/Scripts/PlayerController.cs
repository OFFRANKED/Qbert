using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
	public  Text            scoreText;
    public Text EndGameText;
    public int      Points;
    private int temp;
    private AudioSource     Jump;
    private int live;
    public bool desabled;

    public GameObject Live1;
    public GameObject Live2;
    public GameObject Curse;
    public GameObject GameOverUI;
    public GameObject Level;
    public Transform respawn;

    private SpriteRenderer Main;
    public Sprite I1;
    public Sprite I3;
    public Sprite I7;
    public Sprite I9;


    private void Start ()
    {
        Jump = GetComponent<AudioSource>();
		Points = 0;
		scoreText.text = Points.ToString();
        GetComponent<AudioSource>();
        Main = GetComponent<SpriteRenderer>();
        live = 2;
        GameOverUI.SetActive(false);
        temp = 0;
        desabled = false;

    }
	
	private void Update ()
    {
        KeyInputs ();
        if (live == 0)
        {
            //StartCoroutine(Wait());
            //Time.timeScale = 0f;
            Level.SetActive(false);
            Destroy((GameObject.FindGameObjectWithTag("RedBall")));
            Destroy((GameObject.FindGameObjectWithTag("GreenBall")));
            Destroy((GameObject.FindGameObjectWithTag("PurpleBall")));
            Destroy((GameObject.FindGameObjectWithTag("Snake")));
            GameOverUI.SetActive(true);
            Destroy(this.gameObject);
            Debug.LogError("Game Over!");
        }

    }

	private void KeyInputs(){
        //Movement
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Jump.Play();
            Main.sprite = I1;
            transform.position = transform.position + new Vector3(-0.65f, -0.95f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
		{
            Jump.Play();
            Main.sprite = I3;
            transform.position = transform.position + new Vector3(0.65f, -0.95f, 0.0f);
		}
		if(Input.GetKeyDown(KeyCode.Keypad7))
		{
            Jump.Play();
            Main.sprite = I7;
            transform.position = transform.position + new Vector3(-0.65f,0.95f,0.0f);
		}

		if(Input.GetKeyDown(KeyCode.Keypad9))
		{
            Jump.Play();
            Main.sprite = I9;
            transform.position = transform.position + new Vector3(0.65f,0.95f,0.0f);
		}
	}

	public void AddPoints(int amount)
    {
		Points = Points + amount;
		scoreText.text = Points.ToString();
        EndGameText.text = Points.ToString();
    }
    public void AddCounter(int amount)
    {
        temp = temp + amount;
    }
    public int GetPoints()
    {
        return Points;
    }
    public int GetCounter()
    {
        return temp;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!desabled)
        {
            if (collision.gameObject.CompareTag("Snake") || collision.gameObject.CompareTag("RedBall") || collision.gameObject.CompareTag("PurpleBall"))
            {
                if (live == 2)
                {
                    Live1.SetActive(false);
                    Curse.SetActive(true);
                    Destroy(collision.gameObject);
                    this.transform.position = respawn.position;
                    StartCoroutine(Wait());

                }

                if (live == 1)
                {
                    Live2.SetActive(false);
                    Curse.SetActive(true);
                    Destroy(collision.gameObject);
                    //this.transform.position = respawn.position;
                    StartCoroutine(Wait());

                }
            }
            if (collision.gameObject.CompareTag("GreenBall"))
            {
                AddPoints(100);
                Destroy(collision.gameObject);
            }
        }
        if(collision.gameObject.CompareTag("Elevator"))
        {
            desabled = true;
        }
        if(collision.gameObject.CompareTag("Block"))
        {
            desabled = false;
        }
    }


    private void GameOver()
    {
        
    }
    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(0.5f);
        Curse.SetActive(false);
        live--;
    }
}
