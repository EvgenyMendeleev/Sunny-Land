using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    [SerializeField] private Sprite doorOpen;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D enterArea;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enterArea = GetComponent<BoxCollider2D>();
        enterArea.enabled = false;
    }

    public void Open()
    {
        spriteRenderer.sprite = doorOpen;
        enterArea.enabled = true;
        Debug.Log("Дверь открыта!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
