using UnityEngine;

[AddComponentMenu("Items/Cherry")]
public class Cherry : MonoBehaviour, ITakeable
{
    [SerializeField] [Tooltip("Очки, которые добавятся к игроку.")] private uint addingScore = 0;
    public void GiveTo(Player player)
    {
        //TODO: Реализовать анимацию уничтожения предмета.
        player.CherrysCount += addingScore;
        Destroy(gameObject);
    }
}
