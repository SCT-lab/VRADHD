
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerOrderUpdate : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public Collider colliderBasket;
    public GrabItem appleItem1;
    public GrabItem appleItem5;
    public GrabItem appleItem10;
    public int orderAmount = 0;
    public AudioSource audioPhase;
    public AudioClip audioClip1;

    private void OnTriggerEnter(Collider other)
    {
        var vrcObject = other.gameObject;

        if (other.gameObject.name == "Apple1(Clone)")
        {
            Destroy(vrcObject);
            orderAmount = orderAmount + 1;
            appleItem1.EnableOriginalItem();
            audioPhase.PlayOneShot(audioClip1);
        }

        if (other.gameObject.name == "Apple5(Clone)")
        {
            Destroy(vrcObject);
            orderAmount = orderAmount + 5;
            appleItem5.EnableOriginalItem();
            audioPhase.PlayOneShot(audioClip1);
        }

        if (other.gameObject.name == "Apple10(Clone)")
        {
            Destroy(vrcObject);
            orderAmount = orderAmount + 10;
            appleItem10.EnableOriginalItem();
            audioPhase.PlayOneShot(audioClip1);
        }
    }
}
