using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 movement;
    private PlayerStats playerStats;

    private EnemyStats enemyStats;

    public float cooldown = 2f;
    private float cooldownTimer;

    void Start()
    {
        // initualise reference
        rb = this.GetComponent<Rigidbody2D>();
        playerStats = this.GetComponent<PlayerStats>();
     
    }


    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.fixedDeltaTime; //make the cooldown count down 
        }

        if (cooldownTimer <= 0)
        {
            Attack();
        }

        float horizontal = Input.GetAxisRaw("Horizontal"); //input
        float vertical = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;
    }

 
    private void FixedUpdate()
    {
        if (playerStats == null) return;
        movePlayer(movement);
    }


    void movePlayer(Vector2 direction)
    {
        rb.linearVelocity = direction * playerStats.GetSpeed();
    }

    private void Attack()
    {
        //attack player 
        enemyStats.TakeDamage();
        cooldownTimer = cooldown;
    }

}
