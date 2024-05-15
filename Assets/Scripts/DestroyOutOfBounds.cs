using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    void Update()
    {
        if (transform.position.z < 20)
        {
            Destroy(gameObject);
        }
    }
}
