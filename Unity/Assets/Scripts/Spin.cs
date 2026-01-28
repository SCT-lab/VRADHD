
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Spin : UdonSharpBehaviour
{
     private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
    }
}
