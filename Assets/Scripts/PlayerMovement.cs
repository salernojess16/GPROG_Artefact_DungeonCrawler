using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 movement;
    private PlayerStats playerStats;

    void Start()
    {
        // initualise creference
        rb = this.GetComponent<Rigidbody2D>();
        playerStats = this.GetComponent<PlayerStats>();
    }


    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal"); //input
        float vertical = Input.GetAxisRaw("Vertical");

       

        movement = new Vector2(horizontal, vertical).normalized;
    }


    //fixed update fopr physics movement 
    private void FixedUpdate()
    {
        if (playerStats == null) return;
        movePlayer(movement);
    }


    void movePlayer(Vector2 direction)
    {
        rb.linearVelocity = direction * playerStats.GetSpeed();
    }

}
