using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescaleGrid : MonoBehaviour
{
    [SerializeField] private Transform grid;

    public void OnValueChange(float value)
    {
        grid.localScale = Vector3.one * value;
    }
}
