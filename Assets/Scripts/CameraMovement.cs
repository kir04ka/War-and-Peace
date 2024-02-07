using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float mouseWheelSpeed;
    private float currentRotationX = 0f;

    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis(Vertical);
        float horizontalInput = Input.GetAxis(Horizontal);
        float mouseScrollWheelInput = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(verticalInput * Time.deltaTime * _moveSpeed * Vector3.forward);
        transform.Translate(horizontalInput * Time.deltaTime * _moveSpeed * Vector3.right);
        transform.Translate(mouseScrollWheelInput * Time.deltaTime * mouseWheelSpeed * Vector3.up, Space.World);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveSpeed = 20;
        }
        else
        {
            _moveSpeed = 10;
        }
        //x - local axe, y - global axe
        if (Input.mousePosition.x < left.position.x)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.x > right.position.x)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.y > up.position.y && currentRotationX > -20)
        {
            transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime, Space.Self);
            currentRotationX -= rotationSpeed * Time.deltaTime;
        }
        else if (Input.mousePosition.y < down.position.y && currentRotationX < 50)
        {
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime, Space.Self);
            currentRotationX += rotationSpeed * Time.deltaTime;
        }
    }
}
