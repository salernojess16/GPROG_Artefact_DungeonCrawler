using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private ICameraInterface currentStrategy;
    public Transform player;




    private void Update()
    {
        // how to know when to switch the camera stratergies 
    }



    //switch between different behaviours
    public void SetStrategy(ICameraInterface Strategy)
    {

        currentStrategy = Strategy;


    }
}
