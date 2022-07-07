using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private uint _cherrysCount = 0;
    [SerializeField] private uint _gemsCount = 0;
    [SerializeField] private ScreenUI screenUI;

    public uint CherrysCount 
    {
        get { return _cherrysCount; } 
        set 
        {
            if (value > 0)
            {
                _cherrysCount = value;
                screenUI.UpdateCherrysAndGems(_cherrysCount, _gemsCount);
            }
            else throw new Exception($"SCORES TO PLAYER: Wrong count of cherrys score! Player are giving a {_cherrysCount} cherry score.");
        } 
    }

    public uint GemsCount
    {
        get { return _gemsCount; }
        set
        {
            if (value > 0)
            {
                _gemsCount = value;
                screenUI.UpdateCherrysAndGems(_cherrysCount, _gemsCount);
            }
            else throw new Exception($"SCORES TO PLAYER: Wrong count of gems score! Player are giving a {_gemsCount} gems score.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.TryGetComponent(out ITakeable item)) item.GiveTo(this);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
