using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float maxLifeTime = 15.0f;
    [SerializeField] private Color[] colorsForBig;
    [SerializeField] private Color[] colorsForSmall;
    private PlayerSize playerSizeInfo;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private float size;

    private void Awake()
    {
        playerSizeInfo = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerSize>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    private void Start()
    {
        // Every new enemy block's size is randomized to be between half the player's current size or double..
        size = Random.Range(playerSizeInfo.size * 0.5f, playerSizeInfo.size * 2.0f);
        transform.localScale = Vector3.one * size;

        if (this.size > playerSizeInfo.size)
        {
            sprite.color = colorsForBig[Random.Range(0, colorsForBig.Length)];
        } 
        else if (this.size <= playerSizeInfo.size) 
        {
            sprite.color = colorsForSmall[Random.Range(0, colorsForBig.Length)];
        }

    }

    public void SetMoveDirection(Vector3 direction)
    { 
        rb.AddForce(direction * this.speed);
        Destroy(this.gameObject, maxLifeTime);
    }

}
