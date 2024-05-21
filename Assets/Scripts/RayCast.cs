using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private Ray ray;

    [SerializeField] private float maxDistance;
    [SerializeField] private float radius;

    private bool canFirstSquadMove = false;
    private bool canSecondSquadMove = false;

    void Update()
    {
        ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.magenta);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.tag == "Squad1")
        {
            canFirstSquadMove = true;
            canSecondSquadMove = false;
        }
        else if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.collider.tag == "Squad2")
        {
            canFirstSquadMove = false;
            canSecondSquadMove = true;
        }
    }
}
