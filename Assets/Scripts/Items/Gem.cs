using UnityEngine;

[AddComponentMenu("Items/Gem")]
public class Gem : MonoBehaviour, ITakeable
{
    [SerializeField] [Tooltip("Очки, которые добавятся к игроку.")] private uint addingScore = 0;
    public void GiveTo(Player player)
    {
        //TODO: Реализовать анимацию уничтожения предмета.
        player.GemsCount += addingScore;
        Destroy(gameObject);
    }
}
