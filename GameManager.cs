using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Points;
    public int AddPonts = 50;
    public int HealthAway = 1;
    public int HP;
    public int points;
    public GameObject gameOver;
    public bool GameOver = false;
    public AudioSource CatchorNot;
    public AudioClip Catch;
    public AudioClip NCatch;
   public int DifficaltValue = 1;
    
  
    // Start is called before the first frame update
    void Start()
    {
        CatchorNot = GetComponent<AudioSource>();
        points = 0;
        HP = 3;
        Health.text = "Health: " + HP;
        Points.text = "Points: " + points;
    }

    private void Update()
    {
        if (HP <= 0)
        {
            GameOver = true;
            gameOver.SetActive(true);
           
        }
    }

    public void Catched()
    {
        HP = HP - HealthAway;
        Health.text = "Health: " + HP;
        CatchorNot.PlayOneShot(Catch);
    }
    
   public void Restart()
   {
       SceneManager.LoadScene("DemoScene");
   }
    public void NotCatched()
    {
        points = points + AddPonts;
        Points.text = "Points: " + points;
        CatchorNot.PlayOneShot(NCatch);
        DifficaltValue++;
    }
}
