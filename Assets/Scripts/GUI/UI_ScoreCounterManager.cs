using System;
using UnityEngine.UI;
using UnityEngine;
using GameObserver;

[AddComponentMenu("GUI/UI Score Counter Manager")]
public class UI_ScoreCounterManager : MonoBehaviour
{
    [SerializeField] private Text cherrysCounterText;
    [SerializeField] private Text gemsCounterText;

    public int CherrysCounts { get; private set; } = 0;
    public int GemsCounts { get; private set; } = 0;

    private void Start()
    {
        Player.NotifyScoreCounter += UpdateScores;
    }

    public void UpdateScores(GameEvents gameEvent)
    {
        switch (gameEvent)
        {
            case GameEvents.COLLECT_GEM:
                gemsCounterText.text = (++GemsCounts).ToString();
                break;
            case GameEvents.COLLECT_CHERRY:
                cherrysCounterText.text = (++CherrysCounts).ToString();
                break;
        }
    }
}
