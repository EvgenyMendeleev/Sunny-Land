using UnityEngine;
using UnityEngine.Events;

public class Crank : MonoBehaviour
{
    [SerializeField] private UnityEvent CrankEvent;
    [SerializeField] private Sprite crankDown;
    private bool isOpen = false;
    private SpriteRenderer spriteRenderer;

    private void Start() => spriteRenderer = GetComponent<SpriteRenderer>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isOpen && Input.GetKey(KeyCode.E))
        {
            spriteRenderer.sprite = crankDown;
            CrankEvent?.Invoke();
            isOpen = true;
        }
    }
}
