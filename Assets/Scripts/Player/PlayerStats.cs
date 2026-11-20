using UnityEngine;
using UnityEngine.Rendering;

public class PlayerStats : MonoBehaviour
{
    //the stats are stored in this class

    public float speed = 5f;
    public float hp = 100f;
    private float damage = 10f;
    public bool isKnockedback = false;
    private float knockbackTimer;
    public float knockbackLength = 0.5f;
    public float knockbackForce = 8f;

    public AudioSource hurtSound;

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
   

public float GetSpeed()
    {
        return speed;
    }

    public void TakeDamage(Vector2 enemyPosition)
    {
       
        hp -= damage;
        Vector2 knockbackDirection = ((Vector2)transform.position - enemyPosition).normalized; //knockback in the right direction
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse); //actual knockback
        isKnockedback = true;
        knockbackTimer = knockbackLength;
        hurtSound.Play();
    }

  
}
