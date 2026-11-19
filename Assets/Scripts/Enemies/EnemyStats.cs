using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float hp = 100f;
    public float speed = 2.5f; 
    public float damage = 30f;
    //cooldown speed 
    public float attackDamage = 10;

    public bool isKnockedback = false;
    private float knockbackTimer;
    public float knockbackLength = 0.2f;
    public float knockbackForce = 4f;

    private Rigidbody2D rb;

      void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (knockbackTimer > 0)
        {
            knockbackTimer -= Time.fixedDeltaTime;


            if (knockbackTimer <= 0)

                isKnockedback = false;
        }
    }


    public void TakeDamage(Vector2 playerPosition)
    {
         hp -= damage;


        Vector2 knockbackDirection = ((Vector2)transform.position - playerPosition).normalized; //knockback in the right direction
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse); //actual knockback
        isKnockedback = true;
        knockbackTimer = knockbackLength;
    }


}


