using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MoveBlock : MonoBehaviour
{
    [SerializeField] private XRNode inputSource;
    [SerializeField] private SelectionTracker selectionTracker;
    [SerializeField] private Transform grid;
    private Vector2 inputAxis;
    private bool lowerButton;
    private bool upperButton;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        device.TryGetFeatureValue(CommonUsages.secondaryButton, out upperButton);
        device.TryGetFeatureValue(CommonUsages.primaryButton, out lowerButton);

        float yDir = 0f;
        if (upperButton ^ lowerButton)
        {
            yDir = (upperButton) ? 1f : -1f;
        }

        Vector2 inputAxisAbs = new Vector2(Mathf.Abs(inputAxis.x), Mathf.Abs(inputAxis.y));
        float max = Mathf.Max(inputAxisAbs.x, inputAxisAbs.y);
        Vector3 moveVectorRaw = Vector3.zero;
        if (max == inputAxisAbs.x)
        {
            moveVectorRaw.x = inputAxis.x == 0 ? 0 : Mathf.Sign(inputAxis.x);
        }
        else
        {
            moveVectorRaw.z = inputAxis.y == 0 ? 0 : Mathf.Sign(inputAxis.y);
        }
        moveVectorRaw.y = yDir;
        //Vector3 moveVector = Camera.main.transform.forward * moveVectorRaw.x + Camera.main.transform.right * moveVectorRaw.z;
        GameObject selected = selectionTracker.selected;
        if (selected != null)
        {
            Vector3 newPos = selected.transform.localPosition + moveVectorRaw;
            selected.transform.localPosition = newPos;
        }
    }
}
