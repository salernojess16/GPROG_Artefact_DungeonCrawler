using UnityEngine;

public class Heal : MonoBehaviour
{
    public float value = 5f;
    private GameObject Player;
    public AudioSource sound;
    private PlayerStats playerStats;




    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerStats = Player.GetComponent<PlayerStats>();

    }




    private void OnCollisionEnter2D(Collision2D Player)
    {
        sound.pitch = Random.Range(0.8f, 1.2f);
        AudioSource.PlayClipAtPoint(sound.clip, transform.position);
        playerStats.Heal();
        Destroy(gameObject);
        
    }

}

