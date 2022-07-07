using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    //TODO: �������� ��� ����� ������� ����� Enemy �����������. ����� �� ����� �������� ����� ������ ��� ������ �������.
    private uint health = 100;

    public virtual void TakeDamage(uint damage)
    {
        health -= damage;
        if(health <= 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out Player player)) return;

        //TODO: �������� ��� ���������� ������������� ��������� �� ������ �����������.
        ContactPoint2D[] contactPoints = collision.contacts;
        foreach (ContactPoint2D point in contactPoints)
        {
            if (point.normal.x > 0.7f) player.Death();
            else
            {
                player.GetComponent<InputMovement>().Jump(1.5f);
                TakeDamage(100);
            }
        }
    }
}
