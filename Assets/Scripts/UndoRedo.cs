using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoRedo : MonoBehaviour
{
    public Stack<MazeAction> actions;
    public Stack<MazeAction> undoneActions;
    [SerializeField] public Transform grid;
    
    // Start is called before the first frame update
    void Start()
    {
        actions = new Stack<MazeAction>();
        undoneActions = new Stack<MazeAction>();
    }

    public void OnUndo()
    {
        if (actions.Count != 0)
        {
            MazeAction lastAction = actions.Pop();

            if (lastAction.deleted)
            {
                
                if (lastAction.gameObject != null)
                {
                    lastAction.gameObject.SetActive(true);
                    return;
                }
                
                
                /*
                GameObject respawned = Instantiate(lastAction.prefab, grid);
                respawned.transform.localPosition = lastAction.prevLoc;
                respawned.transform.localRotation = lastAction.prevRot;
                */
                Debug.Log("undo delete");
            }
            else if (lastAction.spawned)
            {
                lastAction.gameObject.SetActive(false);
            }
            else if (lastAction.translated)
            {
                if (lastAction.gameObject == null)
                {
                    return;
                }
                
                Vector3 tempLoc = lastAction.gameObject.transform.localPosition;
                Quaternion tempRot = lastAction.gameObject.transform.localRotation;
                
                lastAction.gameObject.transform.localPosition = lastAction.prevLoc;
                lastAction.gameObject.transform.localRotation = lastAction.prevRot;

                lastAction.prevLoc = tempLoc;
                lastAction.prevRot = tempRot;
            }
            undoneActions.Push(lastAction);

        }
    }
    
    public void OnRedo()
    {
        if (undoneActions.Count != 0)
        {
            MazeAction lastUndoneAction = undoneActions.Pop();
            actions.Push(lastUndoneAction);

            if (lastUndoneAction.deleted)
            {
                lastUndoneAction.gameObject.SetActive(false);
            }
            else if (lastUndoneAction.spawned)
            {
                
                if (lastUndoneAction.gameObject != null)
                {
                    lastUndoneAction.gameObject.SetActive(true);
                    return;
                }
                
                
                /*
                GameObject respawned = Instantiate(lastUndoneAction.prefab, grid);
                respawned.transform.localPosition = lastUndoneAction.prevLoc;
                respawned.transform.localRotation = lastUndoneAction.prevRot;
                */
                
            }
            else if (lastUndoneAction.translated)
            {
                if (lastUndoneAction.gameObject == null)
                {
                    return;
                }
                
                Vector3 tempLoc = lastUndoneAction.gameObject.transform.localPosition;
                Quaternion tempRot = lastUndoneAction.gameObject.transform.localRotation;
                
                lastUndoneAction.gameObject.transform.localPosition = lastUndoneAction.prevLoc;
                lastUndoneAction.gameObject.transform.localRotation = lastUndoneAction.prevRot;

                lastUndoneAction.prevLoc = tempLoc;
                lastUndoneAction.prevRot = tempRot;
            }
            actions.Push(lastUndoneAction);
        }  
    }
}
