using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D crankCollider = Physics2D.OverlapCircle(transform.position, 5.0f);
            if (crankCollider.TryGetComponent(out IInteractable interactableItem)) interactableItem.Interacte();
        }
    }
}
