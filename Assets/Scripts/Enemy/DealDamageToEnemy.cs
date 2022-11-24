using UnityEngine;

[AddComponentMenu("Player/DealDamage")]
public class DealDamageToEnemy : MonoBehaviour 
{
    private Player player;
    private PlayerInput playerInput;

    private void Start()
    {
        player = GetComponent<Player>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out Killable enemy)) return;

        ContactPoint2D[] contactPoints = collision.contacts;
        foreach (ContactPoint2D point in contactPoints)
        {
            if (point.normal.y >= 0.7f)
            {
                playerInput.Jump(3.7f);
                enemy.Death();
            }
            else player.Death();
        }
    }
}
