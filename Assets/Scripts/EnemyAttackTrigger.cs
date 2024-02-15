using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private float _time = 0;
    [SerializeField] private float attackRate = 1;

    private bool hasOpener;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyAttacker>())
        {
            hasOpener = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyAttacker>())
        {
            hasOpener = false;
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (hasOpener && _time > attackRate)
        {
            _enemy.Battle();
            _time = 0;
        }
    }
}
