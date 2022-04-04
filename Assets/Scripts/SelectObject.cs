using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private SelectionTracker selectionTracker;
    [SerializeField] private Material selectedMaterial;
    private Renderer renderer;
    public Material originalMaterial;
    private bool interacting;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        
        selectionTracker = canvas.GetComponent<SelectionTracker>();
        Debug.Log(selectionTracker);
        renderer = transform.GetChild(0).GetComponent<Renderer>();
        originalMaterial = renderer.material;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.GetChild(0).position, transform.GetChild(0).localScale);
        Debug.Log("gizmos drawn");
    }
    
    public void OnHoverEnter()
    {
        selectionTracker.selected = this.gameObject;
        renderer.material = selectedMaterial;
        interacting = true;
        originalPos = transform.localPosition;
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
            }
        }
    }

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
            }
        }

    }
}
