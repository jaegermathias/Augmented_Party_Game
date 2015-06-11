using UnityEngine;
using System.Collections;

public class Spielfeld : MonoBehaviour {
	void FixedUpdate() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		int i = 0;
		while (i < vertices.Length) {
			vertices[1].x += (float) 0.005 * Mathf.Sin(Time.time);
			vertices[1].z -= (float) 0.005 * Mathf.Sin(Time.time);
			i++;
		}
		mesh.vertices = vertices;

		GetComponent<MeshCollider>().sharedMesh = null;
		GetComponent<MeshCollider>().sharedMesh = mesh;

	}
}