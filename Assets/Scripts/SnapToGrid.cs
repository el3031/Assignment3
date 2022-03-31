using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private bool shouldSnap;
    [SerializeField] private Transform grid;

    // Update is called once per frame
    void Update()
    {
        if (shouldSnap)
        {
            Vector3 rawPos = transform.localPosition;
            Vector3 newPos = new Vector3(Mathf.Round(rawPos.x), Mathf.Round(rawPos.y), Mathf.Round(rawPos.z));
            transform.localPosition = newPos;

            Vector3 snapped = transform.localRotation.eulerAngles;
            snapped.x = Mathf.Round(snapped.x / 90) * 90;
            snapped.y = Mathf.Round(snapped.y / 90) * 90;
            snapped.z = Mathf.Round(snapped.z / 90) * 90;
            transform.localRotation = Quaternion.Euler(snapped);
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grid"))
        {
            shouldSnap = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grid"))
        {
            shouldSnap = false;
        }
    }
}
