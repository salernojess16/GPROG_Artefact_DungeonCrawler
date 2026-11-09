using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private ICameraStrategy currentStrategy;
    public Transform player;
    public Camera gameCamera;



    private void Start()
    {
        SetStrategy(new FollowPlayer(player));
    }
    private void LateUpdate()    //changed to lateupdate become the player was flickering strangely 
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
