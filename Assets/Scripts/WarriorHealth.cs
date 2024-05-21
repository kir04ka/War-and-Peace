using UnityEngine;
using UnityEngine.UI;

public class WarriorHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int amountToBeDead;

    private int currentDeadAmount = 0;


    void Start()
    {
        healthSlider.maxValue = amountToBeDead;
        healthSlider.value = 0;
        healthSlider.fillRect.gameObject.SetActive(false);
    }

    public void KillWarrior(int amount)
    {
        currentDeadAmount += amount;
        healthSlider.fillRect.gameObject.SetActive(true);
        healthSlider.value = currentDeadAmount;
        if (currentDeadAmount >= amountToBeDead)
        {
            transform.position = transform.position + new Vector3(0, 0, -1000);
            Destroy(gameObject, 0.1f);
        }
    }

}
