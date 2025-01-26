using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text livesText;
    public Text playerScoreText;
    public GameObject player;
    public GameObject gameOverScreen;
    [SerializeField] private float respawnTime = 2.5f;
    [SerializeField] private float InvulTimer = 3.0f;
    [SerializeField] private int lives = 3;
    private int score = 0;

    private void Update()
    {
        DisplayNumLives();
    }

    public void DisplayNumLives()
    {
        if (lives == 3)
        {
            livesText.text = "LIVES:[X][X][X]";
        }
        else if (lives == 2)
        {
            livesText.text = "LIVES:[X][X]";
        }
        else if (lives == 1)
        {
            livesText.text = "LIVES:[X]";
        }
        else
        {
            livesText.text = "LIVES:";
        }
    }

    public void PlayerDied()
    {
        lives--;
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.layer = 7;
        
        if (lives > 0)
        {
            Invoke(nameof(Respawn), respawnTime);
        } 
        else
        {
            GameOver();
        }

    }

    public void Respawn()
    { 
        player.transform.position = Vector3.zero;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        player.GetComponent<BoxCollider2D>().enabled = true;
        Invoke(nameof(TurnOffInvulnerable), InvulTimer);
    }

    public void AddScore()
    {
        score += 100;
        playerScoreText.text = "SCORE:" + score.ToString();
    }

    public void TurnOffInvulnerable()
    {
        player.layer = 8;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }


}
