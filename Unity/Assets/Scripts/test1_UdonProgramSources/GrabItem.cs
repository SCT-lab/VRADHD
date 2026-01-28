
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
public class GrabItem : UdonSharpBehaviour
{
    public GameObject newItemPrefab;
    public Transform spawnLocation;
    public bool originalItem = true;

    public override void Interact()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (newItemPrefab.name.Contains("(Clone)"))
        {

        }
        else
        {
            GameObject existingObject = GameObject.Find(newItemPrefab.name);
            if (existingObject == newItemPrefab && originalItem)
            {

                GameObject newObject = VRCInstantiate(newItemPrefab);
                newObject.transform.position = spawnLocation.position;
                newObject.transform.rotation = spawnLocation.rotation;
                originalItem = false;

                VRC_Pickup pickupComponent = newObject.GetComponent<VRC_Pickup>();
                pickupComponent.pickupable = true;

                DisableUnwantedComponents(newObject); 
            
                
        }
        }
        
        
    }

    private void DisableUnwantedComponents(GameObject obj)
    {
        var udonBehaviourScript = obj.GetComponent<UdonSharpBehaviour>();
        if (udonBehaviourScript != null)
        {
            udonBehaviourScript.enabled = false;

        }
    }

    public void EnableOriginalItem()
    {
        originalItem = true;
    }
}
