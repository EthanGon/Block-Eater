using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    public float size;
    [SerializeField] private float sizeIncreaseAmount = 0.5f;

    private void Start()
    {
        this.size = gameObject.transform.localScale.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            GameObject enemy = collision.gameObject;
            
            if (this.size < 5)
            {
                if (enemy.transform.localScale.x <= this.size)
                {
                    float localScaleX = transform.localScale.x;
                    float localScaleY = transform.localScale.y;
                    float localScaleZ = transform.localScale.z;
                    transform.localScale = new Vector3(localScaleX + sizeIncreaseAmount, localScaleY + sizeIncreaseAmount, localScaleZ + sizeIncreaseAmount);
                    size = transform.localScale.x;
                    Destroy(enemy);
                    FindObjectOfType<GameManager>().AddScore();
                }
                else
                {
                    FindObjectOfType<GameManager>().PlayerDied();
                }
            }
            else
            {
                if (enemy.transform.localScale.x <= this.size)
                {
                    Destroy(enemy);
                    FindObjectOfType<GameManager>().AddScore();
                }
                else
                {
                    FindObjectOfType<GameManager>().PlayerDied();
                }
            }

        }

    }
}
