using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObserver : MonoBehaviour
{
    [Header("Camera observer settings")]
    [SerializeField] [Min(0)] private float smoothCamera;
    [Header("Camera's limits")]
    [SerializeField] private float upperLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
    }

    private void LateUpdate()
    {
        if (playerTransform == null) return;
        Vector2 currentVelocity = playerTransform.transform.position - transform.position;
        transform.position = Vector2.SmoothDamp(transform.position, playerTransform.transform.position, ref currentVelocity, smoothCamera);

        float newX = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        float newY = Mathf.Clamp(transform.position.y, bottomLimit, upperLimit);
        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(rightLimit, upperLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upperLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upperLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
    }
}
