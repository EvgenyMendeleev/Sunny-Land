namespace GameObserver
{
    public enum GameEvents { COLLECT_CHERRY, COLLECT_GEM, STOP_GAME, RESTART_LEVEL }
    public delegate void NotifyHandler(GameEvents gameEvent);
}