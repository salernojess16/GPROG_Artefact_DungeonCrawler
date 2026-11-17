using Unity.VisualScripting;
using UnityEngine;

public class EPatrol : EIstate
{
    private Rigidbody2D rb;
    private EnemyStats enemyStats;

    private float patrolDistance = 1f;
    private Vector2 PointA;
    private Vector2 PointB;

    private Vector2 target;
    private float pauseTime = 1.0f;
    private float pauseTimer = 0f;

    private bool isPausing = false;


    //constructor to pass through references
    public EPatrol(Rigidbody2D rb, EnemyStats enemyStats)
    {
        this.rb = rb;                      //this refers to the variable Belonging here
        this.enemyStats = enemyStats;
    }
    public void Enter()
    {
        //set up point a and b
        PointA = new Vector2(rb.position.x - patrolDistance, rb.position.y);
        PointB = new Vector2(rb.position.x + patrolDistance, rb.position.y);

        target = PointA;

        isPausing = false;
        pauseTimer = 0f;
    }
    public void Execute()
    {
        
        if (Vector2.Distance(rb.position, target) < 0.1f)   //check if its reached its target 
        {
            //pause logic 
            if (!isPausing)
            {
                isPausing = true;
                pauseTimer = pauseTime;
            }

            if (isPausing)
            {
                pauseTimer -= Time.fixedDeltaTime;
            }

            if (pauseTimer <= 0)

            {
                //switch directions
                if (target == PointA)
                {
                    target = PointB;
                }
                else
                {
                    target = PointA;
                }

                isPausing = false;
            }
        }
        //not pausing normal movement 
        else if (!isPausing)
        {
            //move around betwen patrol points 

            Vector2 newPosition = Vector2.MoveTowards(rb.position, target, enemyStats.speed * Time.fixedDeltaTime);

            rb.MovePosition(newPosition);
        }
    }

    public void Exit()
    { 
     //what happens whe nit exits this statte 
     //stop patrol movement 
     //reset patrol point a and b 
    }
}
