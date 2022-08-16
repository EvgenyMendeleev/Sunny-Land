using System;
using System.Collections.Generic;
using UnityEngine;
using GameObserver;

public class Player : MonoBehaviour
{
    public static NotifyHandler NotifyScoreCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.TryGetComponent(out Item item))
        {
            if (item.CompareTag("Cherry")) NotifyScoreCounter?.Invoke(GameEvents.COLLECT_CHERRY);
            else if (item.CompareTag("Gem")) NotifyScoreCounter?.Invoke(GameEvents.COLLECT_GEM);
            item.Dispose();
        }
        
    }

    public void Death()
    {
        GetComponent<Animator>().SetBool("isDeath", true);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.Jump(3.5f);
        playerInput.enabled = false;

        Destroy(gameObject, 3.0f);
    }
}