using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform selected;

    void Start()
    {
        selected = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pivot = selected.position;
        Vector3 axis = Vector3.up;
        float direction = 0;
        if (Input.GetKeyDown("right"))
        {
            Debug.Log("right");
            axis = Vector3.up;
            direction = -1f;
        }
        else if (Input.GetKeyDown("left"))
        {
            axis = Vector3.up;
            direction = 1f;
        }
        else if (Input.GetKeyDown("up"))
        {
            axis = Vector3.forward;
            direction = -1f;
        }
        else if (Input.GetKeyDown("down"))
        {
            axis = Vector3.forward;
            direction = 1f;
        }
        selected.transform.RotateAround(pivot, axis, 90f * direction);

    }

    public void OnRotate()
    {
        
    }
}
