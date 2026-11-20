using UnityEditor;
using UnityEngine;

public class EDeath : EIstate
{
    private Rigidbody2D rb;
    private EnemyStats enemyStats;

    private GameObject coinPrefab; //bneed a reference to the coin prefab to instantiate it 

    //constructor to pass through references
    public EDeath(Rigidbody2D rb, EnemyStats enemyStats, GameObject coinPrefab)
    {
        this.rb = rb;                      //this refers to the variable Belonging here
        this.enemyStats = enemyStats;
        this.coinPrefab = coinPrefab;
    }
    public void Enter()
    { }

    public void Execute()
    {
        Object.Instantiate(coinPrefab, rb.position, Quaternion.identity); //spawn coin where the rb is/was . //used trasnform w=instead of position, was deleted because of destroy 
        
        Object.Destroy(rb.gameObject); //had a problem with this for a while, it isn't a monobehaviour so i couldnt use destroy function, object destroy says to destroy the game object the rb is referring to. same problem with the instantiate.
       
    }

    public void Exit()
    { }


}
