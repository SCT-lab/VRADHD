
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SpinY : UdonSharpBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
