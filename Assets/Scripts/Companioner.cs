using UnityEngine;

public class Companioner : MonoBehaviour
{
    [SerializeField] private Transform _targetYellow;
    [SerializeField] private Transform _targetRed;
    [SerializeField] private float Speed;
    [SerializeField] private GestureClick Gesture;
    [SerializeField] private Animator animator;

    private readonly int OpenTrigger = Animator.StringToHash("Battle");

    private void Start()
    {
        Gesture.OnClick.AddListener((pos) =>
        {
            _targetYellow.position = pos;
        });

    }

    private void Update()
    {
        Vector3 between = _targetRed.position - transform.position;
        animator.SetFloat("Speed", between.magnitude);
        transform.position = Vector3.MoveTowards(transform.position, _targetRed.position, Speed * Time.deltaTime);
        transform.LookAt(_targetRed.position);
    }

}