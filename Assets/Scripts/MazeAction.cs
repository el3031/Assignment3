using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAction
{
    public bool spawned;
    public bool deleted;
    public bool translated;
    public Vector3 prevLoc;
    public Quaternion prevRot;
    public GameObject prefab;
    public GameObject gameObject;
    
    public MazeAction(bool s, bool d, bool t, Vector3 pLoc, Quaternion r, GameObject p, GameObject g)
    {
        spawned = s;
        deleted = d;
        translated = t;
        prevLoc = pLoc;
        prevRot = r;
        prefab = p;
        gameObject = g;
    }
}
