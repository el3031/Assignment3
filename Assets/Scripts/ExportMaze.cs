using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ExportMaze : MonoBehaviour
{
    private GameObject[] blocks;
    [SerializeField] private Dictionary<string, int> blockDictionary;
    [SerializeField] private GameObject[] blockArray;
    [SerializeField] private string filepath;
    
    // Start is called before the first frame update
    async void Start()
    {
        blockDictionary = new Dictionary<string, int>();
        
        for (int i = 0; i < blockArray.Length; i++)
        {
            blockDictionary.Add(blockArray[i].name, i);
        }
    }
    
    public async void OnExport()
    {
        blocks = GameObject.FindGameObjectsWithTag("Blocks");
        
        using (StreamWriter sw = new StreamWriter(filepath))
        {
            foreach (GameObject block in blocks)
            {
                Vector3 pos = block.transform.localPosition;
                Vector3 rot = block.transform.localRotation.eulerAngles;
                string[] nameSplit = block.name.Split('(');
                string nameString = nameSplit[0];
                int name = blockDictionary[nameString];
                string line = name + "," + pos.x + "," + pos.y + ", " + pos.z + "," + rot.x + "," + rot.y + "," + rot.z;
                sw.WriteLine(line);
            }
        }
        
    }
}
