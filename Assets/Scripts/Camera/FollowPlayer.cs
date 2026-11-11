using UnityEngine;

public class FollowPlayer : ICameraStrategy
{
    private Transform player; //reference the player so it knows what to follow 

    private Vector3 offset = new Vector3(0, 2, -3); //offset so its not directly on the player

    public float lerpSpeed = 2f;


   
    public void UpdateCamera(Camera camera)
    {
        //use lerp to gradually move 

        Vector3 targetPosition = player.position + offset;

        camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    //change position of the camera to target position whilst using a lerp to make it move gradually and not instantly 
    }


    public FollowPlayer(Transform player)
    {
        this.player = player;
    }

}
