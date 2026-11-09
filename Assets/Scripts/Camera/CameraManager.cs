using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private ICameraStrategy currentStrategy;
    public Transform player;
    public Camera gameCamera;



    private void Start() //makinng followplayer the first when game starts
    {
        SetStrategy(new FollowPlayer(player));
    }
    private void LateUpdate()    //changed to lateupdate become the player was flickering strangely didntwork but read up its better this way anyway. change rigidbody to interpelaate to fix it aswell 
    {
        UpdateCamera();
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
