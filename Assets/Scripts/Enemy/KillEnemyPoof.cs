using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemyPoof : MonoBehaviour
{
    [SerializeField, Min(0)] private int deltaTime;
    private float time;

    void Start()
    {
        time = Time.time + deltaTime;
    }

    void Update()
    {
        if ((Time.time - time) > deltaTime)
        {
            
        }
    }
}
