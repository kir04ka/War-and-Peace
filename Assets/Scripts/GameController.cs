using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> warriors;

    void Start()
    {

    }

    void Update()
    {

    }

    public void NewWarrior(GameObject warrior)
    {
        warriors.Add(warrior);
    }

}
