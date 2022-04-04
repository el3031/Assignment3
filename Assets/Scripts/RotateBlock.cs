using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RotateBlock : MonoBehaviour
{
    [SerializeField] private XRNode inputSource;
    [SerializeField] private SelectionTracker selectionTracker;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputAxis = Vector3.zero;
        bool lowerButton = false;
        bool upperButton = false;
        
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        device.TryGetFeatureValue(CommonUsages.secondaryButton, out upperButton);
        device.TryGetFeatureValue(CommonUsages.primaryButton, out lowerButton);

        float yDir = 0f;
        if (upperButton ^ lowerButton)
        {
            yDir = (upperButton) ? 1f : -1f;
        }

        Vector3 rotVectorRaw = new Vector3(inputAxis.x, yDir, inputAxis.y);
        GameObject selected = selectionTracker.selected;
        if (selected != null && rotVectorRaw.magnitude != 0f)
        {
            Vector3 axis = FigureOutRotation(rotVectorRaw);
            Vector3 pivot = selected.transform.position;
            selected.transform.RotateAround(pivot, axis, 90f * Mathf.Sign(Vector3.Dot(axis, rotVectorRaw)));
        }
    }

    private Vector3 FigureOutRotation(Vector3 raw)
    {
        Vector3 rawAbs = new Vector3(Mathf.Abs(raw.x), Mathf.Abs(raw.y), Mathf.Abs(raw.z));
        float max = Mathf.Max(rawAbs.x, rawAbs.y, rawAbs.z);
        if (max == rawAbs.x)
        {
            return Vector3.right;
        }
        else if (max == rawAbs.y)
        {
            return Vector3.up;
        }
        else
        {
            return Vector3.forward;
        }
        
        /*
        float[] array = new float[] {raw.x, raw.y, raw.z};
        float[] rawAbs = new float[]{Mathf.Abs(raw.x), Mathf.Abs(raw.y), Mathf.Abs(raw.z)};
        float max = Mathf.Max(rawAbs);
        int maxIndex;
        for (int i = 0; i < rawAbs.Length; i++)
        {
            if (max == rawAbs[i])
            {
                maxIndex = i;
                array[i] = Mathf.Sign(array[i]);
            }
            else
            {
                array[i] = 0;
            }
        }*/
        //return new Vector3(array[0], array[1], array[2]);
    }
}
