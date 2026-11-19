using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public float hp = 100f;
    public float speed = 2.5f; 
    public float damage = 30f;
    //cooldown speed 
    public float attackDamage = 10;

    

    public void TakeDamage()
    {
        hp -= damage;
        //pop up text 

        
    }

}
