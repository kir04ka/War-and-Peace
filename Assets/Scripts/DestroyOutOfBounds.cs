using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float range;
    private Transform warrior;

    private void Start()
    {
        warrior = GameObject.Find("Enemy").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 between = transform.position - warrior.position;
        if (between.magnitude > range)
        {
            Destroy(gameObject);
        }
    }
}
