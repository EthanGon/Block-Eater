using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;
    private float dirX;
    private float dirY;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");

        
            

        


    }

    private void FixedUpdate()
    {
        if (dirX != 0 && dirY != 0)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            rb.velocity = new Vector2(dirX, dirY) * moveSpeed;
        }
    }

}
