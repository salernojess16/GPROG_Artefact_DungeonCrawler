using UnityEngine;

public class EDeath : EIstate
{
    private Rigidbody2D rb;
    private EnemyStats enemyStats;

    //constructor to pass through references
    public EDeath(Rigidbody2D rb, EnemyStats enemyStats)
    {
        this.rb = rb;                      //this refers to the variable Belonging here
        this.enemyStats = enemyStats;
    }
    public void Enter()
    { }

    public void Execute()
    { }

    public void Exit()
    { }


}
