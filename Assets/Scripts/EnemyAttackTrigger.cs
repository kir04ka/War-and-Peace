using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

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
        if (hasOpener)
        {
            _enemy.Battle();
        }
    }
}
