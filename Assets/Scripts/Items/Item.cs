using UnityEngine;

public class Item : MonoBehaviour
{
    public void Dispose()
    {
        Destroy(gameObject);
    }
}
