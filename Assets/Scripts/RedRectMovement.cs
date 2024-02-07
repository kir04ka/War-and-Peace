using System;
using System.Collections.Generic;
using UnityEngine;

public class RedRectMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetYellow;
    private List<Tuple<float, float>> list = new List<Tuple<float, float>> ()
    {
        new Tuple<float, float> (1, -1),
        new Tuple<float, float> (1, 1),
        new Tuple<float , float> (-1, 1),
        new Tuple<float, float> (-1, -1)
    };
    [SerializeField] private int index;

    private void Update()
    {
        transform.position = new Vector3(_targetYellow.position.x + list[index].Item1, _targetYellow.position.y, 
                                         _targetYellow.position.z + list[index].Item2);
    }
}
