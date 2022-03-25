using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform grid;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnBlock()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 forward = Camera.main.transform.forward;
        Instantiate(prefab, cameraPos + forward, Quaternion.identity, grid);
    }
}
