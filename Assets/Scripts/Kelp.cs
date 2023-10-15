using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kelp : MonoBehaviour, IInteractWithPlayer
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        { 
            
        }

        var interactable = collision.gameObject.GetComponent<IInteractWithPlayer>();
        if (interactable == null)
            return;

        if (interactable != null)
            interactable.InteractWithPlayer();
    }
    public void InteractWithPlayer() 
    {
        
    }
}
