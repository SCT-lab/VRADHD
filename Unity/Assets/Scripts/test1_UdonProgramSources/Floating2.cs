
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Floating2 : UdonSharpBehaviour
{
    public float floatSpeed1 = 0.1f;
    public float floatHeight1 = 1.0f;
    private Vector3 originalPosition1;

    public void Start()
    {
        originalPosition1 = transform.position;
        originalPosition1.y = 0.7f;
    }
    
    public void Update()
    {
        float newY1 = originalPosition1.y + Mathf.Sin(Time.time * floatSpeed1) * floatHeight1;
        transform.position = new Vector3(transform.position.x, newY1, transform.position.z);
        
    }
}
