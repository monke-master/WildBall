using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public PauseManager pauseManager;
    public float speed = 5f;
    public ParticleSystem deathParticles;
    public ParticleSystem victoryParticles;
    public float deadHeight = -50;
    
    private Rigidbody ridigbody;
    private Vector3 direction;
    private GameObject availableDoor;
    private Destroyable availableDestroyable;
    private float rotationAngle = 0;
    public int bonusesCollected = 0;
    
    
    void Start()
    {
        ridigbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(-horizontal, 0, -vertical).normalized;

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (availableDoor != null)
            {
                var door = availableDoor.transform.Find("Door").gameObject;
                var doorAngle = door.transform.rotation.eulerAngles.y;
                var force = Quaternion.AngleAxis(doorAngle, Vector3.up) * Vector3.right * 1000;
                Debug.Log(force.ToString());
                door.GetComponent<Rigidbody>().AddForce(force);
                pauseManager.HideHintText();
                availableDoor = null;
            }
            if (availableDestroyable != null) 
            {
                availableDestroyable.Destroy();
                pauseManager.HideHintText();
                if (availableDestroyable.CompareTag("Coin"))
                {
                    bonusesCollected++;
                }

                availableDestroyable = null;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            rotationAngle += 90;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotationAngle -= 90;
        }

        if (transform.position.y < deadHeight)
        {
            GameController.OnGameOver();
        }
    }

    private void FixedUpdate()
    {
        var force = Quaternion.AngleAxis(rotationAngle, Vector3.up) * direction * speed;
        ridigbody.AddForce(force);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Door"))
        {
            availableDoor = other.gameObject;
            pauseManager.ShowHintText();
        }
        if (other.gameObject.CompareTag("Destroyable"))
        {
            availableDestroyable = other.gameObject.GetComponent<Destroyable>();
            pauseManager.ShowHintText();
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            availableDestroyable = other.gameObject.GetComponent<Destroyable>();
            pauseManager.ShowHintText();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Debug.Log("EXIT");
            availableDoor = null;
            pauseManager.HideHintText();
        }
        if (other.gameObject.CompareTag("Destroyable"))
        {
            Debug.Log("EXIT");
            availableDestroyable = null;
            pauseManager.HideHintText();
        }
    }

    public void OnDeath()
    {
        Instantiate(deathParticles, transform.position, transform.rotation).Play();
        gameObject.SetActive(false);
    }

    public void OnVictory()
    {
        Instantiate(victoryParticles, transform.position, transform.rotation).Play();
        gameObject.SetActive(false);
        pauseManager.ShowVictoryText();
    }
}
