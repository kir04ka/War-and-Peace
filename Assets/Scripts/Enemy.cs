using UnityEngine;

public class Enemy : MonoBehaviour
{
    private readonly int BattleTrigger = Animator.StringToHash("Battle");
    
    [SerializeField] private Animator _animator;

    public void Battle()
    {
        _animator.SetTrigger(BattleTrigger);
    }
}
