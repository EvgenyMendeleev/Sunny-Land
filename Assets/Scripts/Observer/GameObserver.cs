namespace GameObserver
{
    public enum GameEvents { COLLECT_CHERRY, COLLECT_GEM, STOP_GAME, RESTART_LEVEL, OPEN_DOOR }
    public delegate void NotifyHandler(GameEvents gameEvent);
}