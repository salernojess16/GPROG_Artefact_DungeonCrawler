using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private ICameraStrategy currentStrategy;
    public Transform player;
    public Camera gameCamera;
    private PlayerStats playerStats;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = player.GetComponent<PlayerStats>();
    }


    private void Start() //makinng followplayer the first when game starts
    {
        SetStrategy(new FollowPlayer(player));
    }
    private void LateUpdate()    //changed to lateupdate become the player was flickering strangely didntwork but read up its better this way anyway. change rigidbody to interpelaate to fix it aswell 
    {
        UpdateCamera();

        if (Input.GetKeyDown(KeyCode.K))//cheatcode
        {
            playerStats.hp = 0;
        }


        if (playerStats.hp <= 0)
        {
            SetStrategy(new DeathScreen());
        }
    }
    private void UpdateCamera()  // check if strategy has been assigned 
    {
        if (currentStrategy != null)
        {
            currentStrategy.UpdateCamera(gameCamera);   //update camera 
        }
    }

   

    
    public void SetStrategy(ICameraStrategy Strategy)  //change which camera is being used
    {

        currentStrategy = Strategy;


    }
}
