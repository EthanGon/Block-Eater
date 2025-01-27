using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    public Text highScoreText;

    private void Start()
    {
        highScoreText.text = "HIGHSCORE:\n" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    


}
