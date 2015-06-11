using UnityEngine;
using System.Collections;

public class Spielfeld : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private Vector3[] normals; 
    void Start()
    {
    }
    //void FixedUpdate()
    //{
       
    //    int i = 0;
    //    while (i < vertices.Length)
    //    {
    //        vertices[1].x += (float)0.005 * Mathf.Sin(Time.time);
    //        vertices[1].z -= (float)0.005 * Mathf.Sin(Time.time);
    //        i++;
    //    }

    //    mesh.vertices = vertices;

    //    GetComponent<MeshCollider>().sharedMesh = null;
    //    GetComponent<MeshCollider>().sharedMesh = mesh;

    //}

    public void neuePos( Vector4 daten)
    {
        
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        vertices[(int)daten.w].x = daten.x;
        vertices[(int)daten.w].z = daten.z;
        mesh.vertices = vertices;
        GetComponent<MeshCollider>().sharedMesh = null;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        Debug.Log("Marker ID " + daten.w +" X: "+daten.x );
    }
}