using UnityEngine;

public class EAttack : EIstate
{

    private Rigidbody2D rb;
    private EnemyStats enemyStats;

    private PlayerStats playerStats;

    private bool playerInRange = false;
    public float attackrange = 1.5f;
    public float cooldown = 2f;
    private float cooldownTimer;
    private Transform target;
    


    //constructor to pass through references
    public EAttack(Rigidbody2D rb, EnemyStats enemyStats, Transform target, PlayerStats playerStats)
    {
        this.rb = rb;                      //this refers to the variable Belonging here
        this.enemyStats = enemyStats;
        this.target = target;
        this.playerStats = playerStats;
    }


    public void Enter()
    { }

    public void Execute()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.fixedDeltaTime; //make the cooldown count down 
        }

        float distanceFromPlayer = Vector2.Distance(rb.position, target.position);//calculate distance from player
        playerInRange = distanceFromPlayer <= attackrange; // if player is range set to true or false if its not

        //if player is in range to attack 
        if (playerInRange)
        {

            if (cooldownTimer <= 0)
            {
                Attack();
            }

        }
        else // if not chase the  player
        {
            Vector2 playerPosition = new Vector2(target.position.x, target.position.y);
            Vector2 newPosition = Vector2.MoveTowards(rb.position, playerPosition, enemyStats.speed * Time.fixedDeltaTime);

            rb.MovePosition(newPosition);
        }
    }

    public void Exit()
    { }

    private void Attack() 
    {
        //attack player 
        playerStats.TakeDamage();
        cooldownTimer = cooldown;
    }

}

