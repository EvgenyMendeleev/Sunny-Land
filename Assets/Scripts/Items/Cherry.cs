using UnityEngine;

[AddComponentMenu("Items/Cherry")]
public class Cherry : MonoBehaviour, ITakeable
{
    [SerializeField] [Tooltip("����, ������� ��������� � ������.")] private uint addingScore = 0;
    public void GiveTo(Player player)
    {
        //TODO: ����������� �������� ����������� ��������.
        player.CherrysCount += addingScore;
        Destroy(gameObject);
    }
}
