
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MenuFadeIn : UdonSharpBehaviour
{
    public GameObject gameObjectAnimation;
    public Animator animatorObject;
    public UdonSharpBehaviour[] udonComponents;
    
    float timingAnimation = 0f;
    private bool animationPlayed = false;
    private bool updateActive = false;
    private bool initializationDone = false;

    void DisableUdonComponents()
    {
        foreach(UdonSharpBehaviour udonComponent in udonComponents)
        {
            udonComponent.enabled = false;
        }
    }

    void EnableUdonComponents()
    {
        foreach(UdonSharpBehaviour udonComponent in udonComponents)
        {
            udonComponent.enabled = true;
        }
    }

    void PlayAnimation()
    {
        var timeAnimation = animatorObject.runtimeAnimatorController.animationClips[0].length;
        updateActive = true;
    }

    void Update()
    {
        if(!initializationDone)
        {
            DisableUdonComponents();
            PlayAnimation();
            initializationDone = true;
        }

        if(updateActive && !animationPlayed)
        {
            timingAnimation -= Time.deltaTime;

            if(timingAnimation < 1)
            {
                animationPlayed = true;
                EnableUdonComponents();
                updateActive = false;
            }
        }     
    }
}
