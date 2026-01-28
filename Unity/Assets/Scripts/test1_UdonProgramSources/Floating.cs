
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Floating : UdonSharpBehaviour
{
    public float floatSpeed = 0.1f;
    public float floatHeight = 1.0f;
    private Vector3 originalPosition;

    public void Start()
    {
        originalPosition = transform.position;
        originalPosition.y = 1.9f;
    }
    
    public void Update()
    {
        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        
    }
}
