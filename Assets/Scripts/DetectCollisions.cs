using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<WarriorHealth>().KillWarrior(1);
        Destroy(gameObject);
        //Destroy(other.gameObject);
    }
}
