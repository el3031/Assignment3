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
        GameObject canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnBlock()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 forward = Camera.main.transform.forward;
        GameObject spawnedBlock = Instantiate(prefab, cameraPos + forward, Quaternion.identity, grid);
        spawnedBlock.transform.parent = grid;
        Debug.Log(spawnedBlock.transform.parent);
        spawnedBlock.transform.localScale = Vector3.one;

    }
}
