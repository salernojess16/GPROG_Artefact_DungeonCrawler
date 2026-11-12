using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public Rigidbody2D rb;              //reference to the physical body and stats for state scripts to reference
    public EnemyStats enemyStats;
    public EIstate CurrentState { get; private set; }
    // current state 

    //transition bool
    bool transitioning = false;


    private EPatrol patrolState;


    public void Awake()
    {
        //initialise the rb and stats and states 
        enemyStats= GetComponent<EnemyStats>();
        rb = GetComponent<Rigidbody2D>();


        patrolState = new EPatrol(rb, enemyStats);
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
        if (CurrentState != null && !transitioning)
            CurrentState.Execute();
        
    }


}
