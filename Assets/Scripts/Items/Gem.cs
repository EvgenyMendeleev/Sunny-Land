using UnityEngine;

[AddComponentMenu("Items/Gem")]
public class Gem : MonoBehaviour, ITakeable
{
    [SerializeField] [Tooltip("����, ������� ��������� � ������.")] private uint addingScore = 0;
    public void GiveTo(Player player)
    {
        //TODO: ����������� �������� ����������� ��������.
        player.GemsCount += addingScore;
        Destroy(gameObject);
    }
}
