using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private bool hasOpener;
    private bool canAttack = true;
    private float coolDown = 1f;

    [SerializeField] private GameObject projectfilePrefab;

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
        if (hasOpener && canAttack)
        {
            _enemy.Battle();
            canAttack = false;
            Invoke("CanAttackAgain", coolDown);
            Instantiate(projectfilePrefab, transform.position, _enemy.transform.rotation);
        }
    }

    private void CanAttackAgain()
    {
        canAttack = true;
    }
}
