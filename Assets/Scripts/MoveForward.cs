using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
