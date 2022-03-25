using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private bool shouldSnap;
    [SerializeField] private Transform grid;
    private Vector3 targetPos;

    
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = grid;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldSnap)
        {
            Vector3 rawPos = transform.localPosition;
            Debug.Log(transform.localPosition);
            Vector3 newPos = new Vector3(Mathf.Round(rawPos.x), Mathf.Round(rawPos.y), Mathf.Round(rawPos.z));
            transform.localPosition = newPos;

            Debug.Log("snapping");
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grid"))
        {
            shouldSnap = true;
            Debug.Log("in contact with grid");
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
