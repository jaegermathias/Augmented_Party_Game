using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Spielfeld : NetworkBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;

	    public void neuePos(Vector4 daten)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        vertices[(int)daten.w].x = daten.x;
        vertices[(int)daten.w].z = daten.z;
        mesh.vertices = vertices;
        GetComponent<MeshCollider>().sharedMesh = null;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        Debug.Log("Marker ID " + daten.w + " X: " + daten.x);
    }
}