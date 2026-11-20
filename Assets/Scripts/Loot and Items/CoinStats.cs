using UnityEngine;

public class CoinStats : MonoBehaviour
{
    public float value = 5f;
    private GameObject Player;
    public AudioSource sound;



    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
       
    }




    private void OnCollisionEnter2D(Collision2D Player)
    {
        AudioSource.PlayClipAtPoint(sound.clip,transform.position);
        Destroy(gameObject);
    }

}
