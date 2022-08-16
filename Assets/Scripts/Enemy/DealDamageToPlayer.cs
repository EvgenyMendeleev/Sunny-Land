using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out Player player)) return;

        ContactPoint2D[] contactPoints = collision.contacts;
        foreach (ContactPoint2D point in contactPoints)
        {
            if (point.normal.y > 0.7f) player.Death();
            else
            {
                player.GetComponent<PlayerInput>().Jump(3.7f);
                Destroy(gameObject);
            }
        }
    }
}
