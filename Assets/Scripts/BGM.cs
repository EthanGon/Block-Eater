using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public GameObject gameOverScreen;
    public AudioSource bgm;

    private void Update()
    {
        if (gameOverScreen.activeInHierarchy)
        {
            bgm.pitch = 0.95f;
        }
        else
        {
            bgm.pitch = 1.0f;
        }
    }

}
