using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    [SerializeField] private Text cherrysCounterText;
    [SerializeField] private Text gemsCounterText;

    public void UpdateCherrysAndGems(uint cherrysCount, uint gemsCount)
    {
        cherrysCounterText.text = cherrysCount.ToString();
        gemsCounterText.text = gemsCount.ToString();
    }
}
