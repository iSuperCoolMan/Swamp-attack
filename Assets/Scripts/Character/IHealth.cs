using UnityEngine.Events;

public interface IHealth
{
    public event UnityAction<int, int> Changed;
    public event UnityAction Finished;

    public void Damage(int damage);
}