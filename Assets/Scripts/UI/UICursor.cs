using UnityEngine;

public class UICursor : MonoBehaviour
{
 
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
}
