using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    static public GameController instance;

    private void Awake()
    {
        instance = this;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public static void OnGameOver()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        player.OnDeath();
        instance.StartCoroutine("GameOver");
    }

    public static void OnLevelComplete()
    {
        if (SceneManager.GetActiveScene().buildIndex < 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bonusesCollected);
        }
        else
        {
            OnVictory();
        }
    }

    public static void OnVictory()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        Debug.Log("VICAS");
        player.OnVictory();
    }
}
