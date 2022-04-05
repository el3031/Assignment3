using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private SelectionTracker selectionTracker;
    private UndoRedo undoRedo;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private GameObject prefab;
    private Renderer renderer;
    public Material originalMaterial;
    private bool interacting;
    private Vector3 originalPos;
    private Quaternion originalRot;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        
        selectionTracker = canvas.GetComponent<SelectionTracker>();
        undoRedo = canvas.GetComponent<UndoRedo>();
        Debug.Log(canvas);
        renderer = transform.GetChild(0).GetComponent<Renderer>();
        originalMaterial = renderer.material;

    }
    
    public void OnHoverEnter()
    {
        if (this.gameObject == null)
        {
            return;
        }
        
        selectionTracker.selected = this.gameObject;
        selectionTracker.prefab = prefab;
        renderer.material = selectedMaterial;
        interacting = true;
        originalPos = transform.localPosition;
        originalRot = transform.localRotation;
    }

    public void OnHoverExit()
    {
        selectionTracker.selected = null;
        renderer.material = originalMaterial;

        Collider[] hitColliders = Physics.OverlapBox(transform.GetChild(0).position, transform.GetChild(0).localScale * transform.parent.localScale.x /2 * 0.9f, transform.rotation);
        foreach (Collider c in hitColliders)
        {
            if (c.CompareTag("Blocks") && c.transform != transform)
            {
                transform.localPosition = originalPos;
                return;
            }
        }
        if (this.gameObject != null)
        {
            MazeAction action = new MazeAction(false, false, true, originalPos, originalRot, prefab, this.gameObject);
            undoRedo.actions.Push(action);
        }
    }

/*
    public void OnSelectEnter()
    {
        originalPos = transform.localPosition;
    }

    public void OnSelectExit()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.GetChild(0).position, transform.GetChild(0).localScale * transform.parent.localScale.x /2 * 0.9f, transform.rotation);
        foreach (Collider c in hitColliders)
        {
            if (c.CompareTag("Blocks") && c.transform != transform)
            {
                transform.localPosition = originalPos;
                return;
            }
        }

        MazeAction action = new MazeAction(false, false, true, transform.localPosition, transform.localRotation, prefab, this.gameObject);
        undoRedo.actions.Push(action);
    }
    */
}
