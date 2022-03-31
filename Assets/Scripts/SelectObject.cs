using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private SelectionTracker selectionTracker;
    [SerializeField] private Material selectedMaterial;

    private Renderer renderer;
    private Material originalMaterial;
    private bool hovered = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        
        selectionTracker = canvas.GetComponent<SelectionTracker>();
        renderer = transform.GetChild(0).GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }
    
    public void OnSelectEnter()
    {
        hovered = true;
        selectionTracker.selected = this.gameObject;
        renderer.material = selectedMaterial;
        Debug.Log("selected");
    }

    // Update is called once per frame
    public void OnSelectExit()
    {
        hovered = false;
        selectionTracker.selected = null;
        renderer.material = originalMaterial;
    }
}
