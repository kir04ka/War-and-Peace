using System;
using UnityEngine;

public class SelectUnits : MonoBehaviour
{
    [SerializeField] private Texture selectTexture;

    private Ray ray;
    private RaycastHit hit;

    private Vector3 mouseStartPosition;
    private Vector3 selectionStartPoint;
    private Vector3 selectionEndPoint;

    private float mouseX;
    private float mouseY;
    private float selectionHeight;
    private float selectionWidth;

    private bool selecting;

    private GameController gameController;

    void Start()
    {
        gameController = GetComponent<GameController>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selecting = true;
            mouseStartPosition = Input.mousePosition;

            ray = Camera.main.ScreenPointToRay(mouseStartPosition);

            if (Physics.Raycast(ray, out hit))
            {
                selectionStartPoint = hit.point;
            }
        }

        mouseX = Input.mousePosition.x;
        mouseY = Screen.height - Input.mousePosition.y;
        selectionWidth = mouseStartPosition.x - mouseX;
        selectionHeight = Input.mousePosition.y - mouseStartPosition.y;

        if (Input.GetMouseButtonUp(0)) 
        {
            selecting = false;
            DeselectAll();

            if (mouseStartPosition == Input.mousePosition)
            {
                SingleSelect();
            }
            else
            {
                MultiSelect();
            }
        }
    }

    private void OnGUI()
    {
        if (selecting)
        {
            GUI.DrawTexture(new Rect(mouseX, mouseY, selectionWidth, selectionHeight), selectTexture);
        }
    }

    private void MultiSelect()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            selectionEndPoint = hit.point;
        }

        SelectHightlighted();
    }

    private void SelectHightlighted()
    {
        foreach (GameObject warrior in gameController.warriors)
        {
            float x = warrior.transform.position.x;
            float z = warrior.transform.position.z;

            if (x > selectionStartPoint.x && x < selectionEndPoint.x || x < selectionStartPoint.x && x > selectionEndPoint.x)
            {
                if (z > selectionStartPoint.z && z < selectionEndPoint.z || z < selectionStartPoint.z && z > selectionEndPoint.z)
                {
                    warrior.GetComponent<WarriorController>().isSelected = true;
                }
            }
        }
    }

    private void SingleSelect()
    {
        if (hit.collider.gameObject.tag == "Friend")
        {
            hit.collider.gameObject.GetComponent<WarriorController>().isSelected = true;
        }
    }

    private void DeselectAll()
    {
        foreach (GameObject warrior in gameController.warriors)
        {
            warrior.GetComponent<WarriorController>().isSelected = false;
        }
    }
}
