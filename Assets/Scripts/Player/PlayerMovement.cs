using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour

{

    public Rigidbody2D rb;
    public Vector2 movement;
    private PlayerStats playerStats;

    private EnemyStats enemyStats;

    public float cooldown = 2f;
    private float cooldownTimer;
    public float attackrange = 1.5f;

    public GameObject popUpPrefab;

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
            //Debug.Log(cooldownTimer);
        }

        if (Input.GetMouseButtonDown(0) && cooldownTimer <= 0)
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
        //check if there is an enemy 
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, attackrange);
        //collioded with something, retrieve this if it has it
        if (enemy != null)
        {
            enemyStats = enemy.GetComponent<EnemyStats>();

            if (enemyStats != null) //if it has this,its an enemy, carry out take damage 
            {
                enemyStats.TakeDamage();
                Debug.Log("hit enemy");

                //popup text 

                Vector2 randomOffset = Random.insideUnitCircle * 1f;
              GameObject popUp = Instantiate(popUpPrefab, (Vector2)enemy.transform.position+randomOffset, Quaternion.identity);
                popUp.GetComponentInChildren<TMP_Text>().text = enemyStats.damage.ToString();
            }
        }

        //change sprite or whatever later when i figure this out 
        cooldownTimer = cooldown;
      

    }

}
