using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColorSet : MonoBehaviour
{

    public List<Mesh> meshes = new List<Mesh>();

    void Start()
    {
        GetComponent<MeshFilter>().mesh = meshes[PlayerPrefs.GetInt("SelectCarColor")];
        Destroy(this,1f);
    }

   
}
