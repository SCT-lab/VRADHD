
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Floating3 : UdonSharpBehaviour
{
    public float floatSpeed2 = 0.1f;
    public float floatHeight2 = 1.0f;
    private Vector3 originalPosition2;

    public void Start()
    {
        originalPosition2 = transform.position;
        originalPosition2.y = 1.3f;
    }
    
    public void Update()
    {
        float newY2 = originalPosition2.y + Mathf.Sin(Time.time * floatSpeed2) * floatHeight2;
        transform.position = new Vector3(transform.position.x, newY2, transform.position.z);
        
    }
}
