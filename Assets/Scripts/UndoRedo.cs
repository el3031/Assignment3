using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoRedo : MonoBehaviour
{
    public Stack<Action> actions;
    public Stack<Action> undoneActions;
    [SerializeField] public Transform grid;
    
    // Start is called before the first frame update
    void Start()
    {
        actions = new Stack<Action>();
        undoneActions = new Stack<Action>();
    }

    public void OnUndo()
    {
        if (actions.Count != 0)
        {
            Action lastAction = actions.Pop();

            if (lastAction.deleted)
            {
                GameObject respawned = Instantiate(lastAction.prefab, grid);
                respawned.transform.localPosition = lastAction.prevLoc;
                respawned.transform.localRotation = lastAction.prevRot;
            }
            else if (lastAction.spawned)
            {
                Destroy(lastAction.gameObject);
            }
            else if (lastAction.translated)
            {
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
            Action lastUndoneAction = undoneActions.Pop();
            actions.Push(lastUndoneAction);

            if (lastUndoneAction.deleted)
            {
                Destroy(lastUndoneAction.gameObject);
            }
            else if (lastUndoneAction.spawned)
            {
                GameObject respawned = Instantiate(lastAction.prefab, grid);
                respawned.transform.localPosition = lastAction.prevLoc;
                respawned.transform.localRotation = lastAction.prevRot;
            }
            else if (lastUndoneAction.translated)
            {
                Vector3 tempLoc = lastAction.gameObject.transform.localPosition;
                Quaternion tempRot = lastAction.gameObject.transform.localRotation;
                
                lastAction.gameObject.transform.localPosition = lastAction.prevLoc;
                lastAction.gameObject.transform.localRotation = lastAction.prevRot;

                lastAction.prevLoc = tempLoc;
                lastAction.prevRot = tempRot;
            }
            actions.Push(lastUndoneAction);
        }  
    }
}
