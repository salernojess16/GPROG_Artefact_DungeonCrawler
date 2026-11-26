using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour

{

    public Rigidbody2D rb;
    public Vector2 movement;
    private PlayerStats playerStats;

    private EnemyStats enemyStats;

    public float cooldown = 0.5f;
    private float cooldownTimer;
    public float attackrange = 2f;
    public AudioSource sound;

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
            cooldownTimer -= Time.deltaTime; //make the cooldown count down 
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

        //only move if its not knockbacked
        if (!playerStats.isKnockedback)
        {
            movePlayer(movement);
        }
    }


    void movePlayer(Vector2 direction)
    {
        rb.linearVelocity = direction * playerStats.GetSpeed();
    }

    private void Attack()
    {
        sound.pitch = Random.Range(0.8f, 1.2f);
        sound.Play();
        //check for enemies in an array
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackrange);
        //collioded with something, retrieve this if it has it
        foreach (Collider2D enemy in enemies)
        {
            enemyStats = enemy.GetComponent<EnemyStats>();

            if (enemyStats != null) //if it has this,its an enemy, carry out take damage 
            {
                //Debug.Log("Detected: ");
                cooldownTimer = cooldown; //reset timer
                enemyStats.TakeDamage(transform.position);
                
               
                //popup text
                Vector2 randomOffset = Random.insideUnitCircle * 1f;
              GameObject popUp = Instantiate(popUpPrefab, (Vector2)enemy.transform.position+randomOffset, Quaternion.identity);
                popUp.GetComponentInChildren<TMP_Text>().text = enemyStats.damage.ToString();

                break;
            }
        }

        //change sprite or whatever later when i figure this out 
       
      

    }

}
