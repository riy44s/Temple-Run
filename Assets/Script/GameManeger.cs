using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public int score;
    public static GameManeger inst;
    public TextMeshProUGUI scoreText;
    public player playerMovement;
    public AudioSource audio1;
    public int livesCount = 3;
  //  public TextMeshProUGUI livesText;
    public GameObject gameover;
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }
    public void IncrementScore()
    {
        audio1.Play();
        score++;
        scoreText.text = score.ToString();
        playerMovement.speed += playerMovement.playerMovementSpeed;
    }
    private void Awake()
    {
        inst = this;
    }
    public void Lives()
    {
        livesCount--;
      //  livesText.text = livesCount.ToString(); 
        if(livesCount <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        gameover.SetActive(true);   
    }
}
