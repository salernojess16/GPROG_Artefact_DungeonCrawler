using UnityEngine;

public class DeathScreen : ICameraStrategy
{
    public float lerpSpeed = 0.75f;
    private float ZoomOutAmount = 6f;
    private float zoom;
    private float MaxZoomedOut = 6f;
    private bool hasInitialised = false; //not a monobehavour 

  
    public void UpdateCamera(Camera camera)
    {
        if (!hasInitialised)
        {
            zoom = camera.orthographicSize;
            hasInitialised = true;
            Debug.Log("has intitialised");
        }

        zoom = Mathf.Lerp(zoom,ZoomOutAmount,Time.deltaTime * lerpSpeed);

        if (zoom >= MaxZoomedOut)
        {
            zoom = MaxZoomedOut;
        }

        camera.orthographicSize = zoom;

        Debug.Log("has zoomed out ");


       
    }
}
