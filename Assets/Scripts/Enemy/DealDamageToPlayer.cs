using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour 
{
    [SerializeField] private GameObject enemyPoof;
    [SerializeField] private float time;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out Player player)) return;

        ContactPoint2D[] contactPoints = collision.contacts;
        foreach (ContactPoint2D point in contactPoints)
        {
            if (point.normal.y <= 0.25f)
            {
                player.GetComponent<PlayerInput>().Jump(3.7f);
                GameObject instanteatedEnemyPoof = Instantiate(enemyPoof, transform.position, Quaternion.identity);
                Destroy(instanteatedEnemyPoof, time);
                Destroy(gameObject);
            }
            else player.Death();
        }
    }
}
