using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private SelectionTracker selectionTracker;
    
    // Start is called before the first frame update
    public void OnDestroy()
    {
        if (selectionTracker.selected != null)
        {
            Destroy(selectionTracker.selected);
        }
    }
}
