using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //the stats are stored in this class

    public float speed = 5f;
    public float hp = 100f;
    private float damage = 10f;


    public float GetSpeed()
    {
        return speed;
    }

    public void TakeDamage()
    {
        hp -= damage;
    }

  
}
