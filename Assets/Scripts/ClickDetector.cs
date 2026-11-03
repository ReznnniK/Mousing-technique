using UnityEngine;
using UnityEngine.InputSystem;

public class ClickDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 pos= Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(pos);
            Debug.DrawRay(ray.origin,ray.direction*100f,Color.red,2f);
        }
        
    }
}
