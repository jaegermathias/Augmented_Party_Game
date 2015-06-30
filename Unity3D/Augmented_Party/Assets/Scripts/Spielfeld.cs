using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Spielfeld : NetworkBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    //void FixedUpdate()
    //{
    //    Mesh mesh = GetComponent<MeshFilter>().mesh;
    //    Vector3[] vertices = mesh.vertices;
    //    Vector3[] normals = mesh.normals;
    //    int i = 0;
    //    while (i < vertices.Length)
    //    {
    //        vertices[3].x += (float)0.005 * Mathf.Sin(Time.time);
    //        vertices[3].z -= (float)0.005 * Mathf.Sin(Time.time);
    //        i++;
    //    }
    //    mesh.vertices = vertices;

    //    GetComponent<MeshCollider>().sharedMesh = null;
    //    GetComponent<MeshCollider>().sharedMesh = mesh;

    //}
    public void neuePos(Vector4 daten)
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        switch ((int)daten.w)
        {
            case 0:
                vertices[1].x = daten.x;
                vertices[1].z = daten.z;
                break;
            case 1:
                vertices[0].x = daten.x;
                vertices[0].z = daten.z;
                break;
            case 2:
                vertices[3].x = daten.x;
                vertices[3].z = daten.z;
                break;
            case 3:
                vertices[6].x = daten.x;
                vertices[6].z = daten.z;
                break;
            case 4:
                vertices[7].x = daten.x;
                vertices[7].z = daten.z;
                break;
            case 5:
                vertices[8].x = daten.x;
                vertices[8].z = daten.z;
                break;
            case 6:
                vertices[5].x = daten.x;
                vertices[5].z = daten.z;
                break;
            case 7:
                vertices[2].x = daten.x;
                vertices[2].z = daten.z;
                break;
            default:
                //vertices[4].x = 0;
                //vertices[4].z = 0;
                break;
        }
        vertices[4].x = 0;
        vertices[4].z = 0;

        mesh.vertices = vertices;
        GetComponent<MeshCollider>().sharedMesh = null;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        Debug.Log("Marker ID " + daten.w + " X: " + daten.x);
    }
}