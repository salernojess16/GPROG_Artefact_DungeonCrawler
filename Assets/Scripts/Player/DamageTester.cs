using UnityEngine;




public class DamageObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats stats = other.GetComponent<PlayerStats>();

        if (stats != null)
        {
            stats.hp -= 10;
            Debug.Log("Player HP: " + stats.hp);
        }
    }
}