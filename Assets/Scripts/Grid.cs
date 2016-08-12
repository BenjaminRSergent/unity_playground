using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour {
	public int xSize = 10;
	public int ySize = 10;
	private Vector3[] vertices;

	void Awake () {
		StartCoroutine(Generate ());
	}

	IEnumerator Generate () {
		MeshFilter filter = GetComponent<MeshFilter>();
		vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		Vector2[] uv = new Vector2[vertices.Length];
		Vector4[] tangents = new Vector4[vertices.Length];
		Vector4 tangent = new Vector4(1,0,0,-1);
		filter.name = "Procedural Grid";

		WaitForSeconds wait = new WaitForSeconds (0.05f);
		int index = 0;
		for (int y = 0; y < xSize + 1; y++) {
			for (int x = 0; x < ySize + 1; x++) {
				uv [index] = new Vector2 ((float)x / xSize, (float)y / ySize);
				vertices [index] = new Vector3 (x, y, 0);
				tangents[index] = tangent;
				index++;
			}
		}

		filter.mesh.vertices = vertices;
		filter.mesh.uv = uv;
		filter.mesh.tangents = tangents;

		int[] triangles = new int[6 * xSize * ySize];

		index = 0;
		int offset = 0;
		for (int ySquare = 0; ySquare < ySize; ySquare++) {
			for (int xSquare = 0; xSquare < xSize; xSquare++) {
				triangles [index] = offset + xSize + 1;
				triangles [index + 1] = offset + 1;
				triangles [index + 2] = offset + 0;
				triangles [index + 3] = offset + 1;
				triangles [index + 4] = offset + xSize + 1;
				triangles [index + 5] = offset + xSize + 2;

				index += 6;
				offset++;

				filter.mesh.triangles = triangles;

				yield return wait;
			}
			offset++;
		}

		filter.mesh.RecalculateNormals ();
	}

	void OnDrawGizmos () {
		if (vertices == null) {
			return;
		}
		Gizmos.color = Color.black;

		for(int index = 0; index < vertices.Length; index++) {
			Gizmos.DrawSphere(transform.TransformPoint(vertices[index]), 0.1f);
		}
	}
}
