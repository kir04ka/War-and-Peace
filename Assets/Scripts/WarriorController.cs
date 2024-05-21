using UnityEngine;

public class WarriorController : MonoBehaviour
{
    private Vector3 targetPosition;

    private bool isRunning;

    private Animator animator;

    public bool isSelected;

    [SerializeField] private float duration;

    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        GameController gameController = controller.GetComponent<GameController>();
        gameController.NewWarrior(gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            Ray ray;
            RaycastHit hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                isRunning = true;
                targetPosition.x = hit.point.x;
                targetPosition.y = 0;
                targetPosition.z = hit.point.z;
            }
        }

        if (isRunning && !Mathf.Approximately(transform.position.magnitude, targetPosition.magnitude))
        {
            transform.LookAt(targetPosition);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 1 / (duration * 
                                             (Vector3.Distance(transform.position, targetPosition))));
            CheckAnimation();
        }
        else if (isRunning && Mathf.Approximately(transform.position.magnitude, targetPosition.magnitude))
        {
            isRunning = false;
            CheckAnimation();
        }
    }

    private void CheckAnimation()
    {
        if (isRunning && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.Play("Walk");
        }
        else if (!isRunning && animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            animator.Play("Idle");
        }
    }
}
