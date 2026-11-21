using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UIDeathScreen : MonoBehaviour
{
    public PlayerStats playerStats;
    private Image image;


    private void Start()
    {

        image = GetComponent<Image>();
        
    }

    private void Update()
    {
        if (playerStats.isDead)
        {
            Color imageColour = image.color;
            imageColour.a = 0.1f;
            image.color = imageColour;
        }
        else
        {
            Color imageColour = image.color;
            imageColour.a = 0.0f;
            image.color = imageColour;
        }
    }

}
