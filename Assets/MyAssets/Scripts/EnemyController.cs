using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private int         Rand;
	private  AudioSource Jump;
    public PlayerController player;
    public GameObject Snake;

	// Use this for initialization
	void Start () {
		Jump = GetComponent<AudioSource> ();
		InvokeRepeating ("EnemyMovementController", 2, 1);
	}

	void EnemyMovementController()
    {
		Rand = UnityEngine.Random.Range (1, 100);
        if (tag == "Snake")
        {
            if (Rand <= 25)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(0.65f, -0.95f, 0.0f);
            }

            if (Rand >= 26 && Rand <= 50)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(-0.65f, 0.95f, 0.0f);
            }


            if (Rand >= 51 && Rand <= 75)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(-0.65f, -0.95f, 0.0f);
            }


            if (Rand >= 76 && Rand <= 100)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(0.65f, 0.95f, 0.0f);
            }
        }

        if(tag=="RedBall" || tag =="PurpleBall")
        {
           Rand = UnityEngine.Random.Range(1, 100);
            if (Rand <= 50)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(0.65f, -0.95f, 0.0f);
            }
            
            if (Rand >= 51 && Rand <= 100)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(-0.65f, -0.95f, 0.0f);
            }
            
        }

        if (tag == "GreenBall")
        {
            Rand = UnityEngine.Random.Range(1, 100);
            if (Rand <= 25)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(0.65f, -0.95f, 0.0f);
            }

            if (Rand >= 26 && Rand <= 50)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(-0.65f, 0.95f, 0.0f);
            }


            if (Rand >= 51 && Rand <= 75)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(-0.65f, -0.95f, 0.0f);
            }


            if (Rand >= 76 && Rand <= 100)
            {
                Jump.Play();
                transform.position = transform.position + new Vector3(0.65f, 0.95f, 0.0f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (tag == "Snake")
            {
                Debug.LogWarning("Destroyed !");
                //StartCoroutine(Wait());
                
                // Destroy(collision.gameObject);
            }
            if(tag == "RedBall")
            {
                Debug.LogWarning("Destroyed !");
                //StartCoroutine(Wait());

                // Destroy(collision.gameObject);
            }
            if (tag == "GreenBall")
            {
                //player.AddPoints(100);
                Destroy(GameObject.FindWithTag("GreenBall"));
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("HEnd"))
        {
            if(tag == "PurpleBall")
            {
                Instantiate(Snake, transform.position, transform.rotation);
                Destroy(GameObject.FindWithTag("PurpleBall"));
                Debug.LogWarning("TODO: repalce Snake here !");
            }
            
        }
    }
    
}

