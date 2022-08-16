using UnityEngine;

namespace StateMachine
{
    //TODO: Наверное, можно сделать enum для того, чтобы в классах Behaviour врагов можно было понять, что метод UpdateState возвращает.
    public interface IEnemyState
    {
        public bool UpdateState();
    }
}