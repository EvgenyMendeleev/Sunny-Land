using UnityEngine;

namespace StateMachine
{
    //TODO: ��������, ����� ������� enum ��� ����, ����� � ������� Behaviour ������ ����� ���� ������, ��� ����� UpdateState ����������.
    public interface IEnemyState
    {
        public bool UpdateState();
    }
}