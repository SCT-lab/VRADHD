
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MusicButton : UdonSharpBehaviour
{

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioClip musicClip1;
    public Material redMaterial;
    public Material greenMaterial;
    public Material orangeMaterial;

    public Renderer objectRenderer;
    public bool isPlaying;
    
    public void Start()
    {
        isPlaying = audioSource1.isPlaying;
        objectRenderer.material = redMaterial;
    }
    public override void Interact()
    {
        if (!isPlaying)
        {
            if(audioSource2.isPlaying)
            {
                audioSource2.Pause();
                updateMaterial(audioSource2);
            }
            else if(audioSource3.isPlaying)
            {
                audioSource3.Pause();
                updateMaterial(audioSource3);
            }
            else if(audioSource4.isPlaying)
            {
                audioSource4.Pause();
                updateMaterial(audioSource4);
            }
            audioSource1.clip = musicClip1;
            audioSource1.Play();
        }
        else if (isPlaying)
        {
            audioSource1.Pause();
        }

        isPlaying = !isPlaying;
        updateMaterial(audioSource1);
    }

    private void updateMaterial(AudioSource audioSource)
    {
        Renderer objectRenderer = audioSource.GetComponent<Renderer>();
        objectRenderer.material = isPlaying ? greenMaterial : orangeMaterial;
    }
}
