using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject itemPoof;
    [SerializeField] private float time;
    public void Dispose()
    {
        GameObject poofAnim = Instantiate(itemPoof, transform.position, Quaternion.identity);
        Destroy(poofAnim, time);
        Destroy(gameObject);
    }
}
