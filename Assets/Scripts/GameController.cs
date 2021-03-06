﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] Hazards;
    public Vector3 spawnvalues;
    public int Hazardcount;
    public float spawnwait;
    public float startwait;
    public float wavewait;
    private int score;
    public Text Scoretext;
    public Text restarttext;
    public Text gameovertext;
    private bool gameOver;
    private bool restart;    

    void Start()
    {
        gameOver = false;
        restart = false;
        restarttext.text = "";
        gameovertext.text = "";        
        score = 0;
        UpdateScore();
        StartCoroutine (Spawnwaves());               
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator Spawnwaves ()
    {
        yield return new WaitForSeconds(startwait);
        while(true)
        {
            for (int i = 0; i <= Hazardcount; i++)
            {
                GameObject hazard = Hazards[Random.Range (0,Hazards.Length)];
                Vector3 spawnposition = new Vector3(Random.Range(-spawnvalues.x, spawnvalues.x), spawnvalues.y, spawnvalues.z);
                Quaternion spawnrotation = Quaternion.identity;
                Instantiate(hazard, spawnposition, spawnrotation);
                yield return new WaitForSeconds(spawnwait);
            }

            yield return new WaitForSeconds(wavewait);
            if (gameOver)
            {
                restarttext.text = "Press 'M' for Restart";
                restart = true;
                break;
            }
            
        }
        
    }

    public void AddScore (int newScorevalue)
    {
        score += newScorevalue;
        UpdateScore();
    }

    void UpdateScore()
    {
        Scoretext.text = "Points: " + score;
        if (score >= 100)
        {
            gameovertext.text = "You win! Game created by David Molina";
            gameOver = true;
            restart = true;
        }
    }

    public void Gameover()
    {
        gameovertext.text = "Game Over; Game created by David Molina";
        gameOver = true;
    }
}
