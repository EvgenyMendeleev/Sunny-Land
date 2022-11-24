using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Enemy/Killable")]
public class Killable : MonoBehaviour
{
    [SerializeField] private GameObject enemyPoof;
    [SerializeField] private float time;

    public void Death()
    {
        GameObject instanteatedEnemyPoof = Instantiate(enemyPoof, transform.position, Quaternion.identity);
        Destroy(instanteatedEnemyPoof, time);
        Destroy(gameObject);
    }
}
