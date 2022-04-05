using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private SelectionTracker selectionTracker;
    [SerializeField] private UndoRedo undoRedo;
    
    // Start is called before the first frame update
    public void OnDestroy()
    {
        if (selectionTracker.selected != null)
        {
            MazeAction action = new MazeAction(false, true, false, selectionTracker.selected.transform.localPosition, selectionTracker.selected.transform.localRotation, selectionTracker.prefab, selectionTracker.selected);
            undoRedo.actions.Push(action);
            selectionTracker.selected.SetActive(false);
            selectionTracker.selected = null;
        }
    }
}
