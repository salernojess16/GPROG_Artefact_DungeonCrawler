using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public Rigidbody2D rb;              //references for state scripts to reference
    public EnemyStats enemyStats;
    private Transform Player;
    private PlayerStats playerStats;

    public float playerDistance = 2f;


    
    public EIstate CurrentState { get; private set; }
    // current state 

    //transition bool
    bool transitioning = false;


    private EPatrol patrolState;
    private EAttack attackState;


    public void Awake()
    {
        //initialise the rb and stats and states 
        enemyStats= GetComponent<EnemyStats>();
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = Player.GetComponent<PlayerStats>();


        patrolState = new EPatrol(rb, enemyStats);
        attackState = new EAttack(rb, enemyStats, Player, playerStats);
        ChangeStateCheck(patrolState);

    }
    public void ChangeStateCheck(EIstate newState)
    {
        //is it ready for a state change? 
        if (CurrentState == newState || transitioning)
            return;

        ChangeState(newState);      //note can see how this is much more modular and cleaner than a switch
                                    //based approach 
    }

    
    private void ChangeState(EIstate newState)
    {
        //actual changestate logic

        transitioning = true;
        //exit previous state
        if (CurrentState != null)
            CurrentState.Exit();

        CurrentState = newState;

        //enter sequence

        if (CurrentState != null)
            CurrentState.Enter();

        transitioning = false;
    }


    // pass update to states - not a monobehaviour 
    public void FixedUpdate()
    {
        //check if player is close enough to activate attack state
        float DistanceToPlayer = Vector2.Distance(rb.position, Player.position); //distance from enemy to player
    

        if (DistanceToPlayer < playerDistance)
        {
            ChangeStateCheck(attackState);
        }
        else
        {
            ChangeStateCheck(patrolState);
        }


        if (CurrentState != null && !transitioning)
            CurrentState.Execute();
        
    }


}
