using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CubeGenerator : MonoBehaviour {
	public int xSize = 10;
	public int ySize = 10;
	public int zSize = 10;

	private Vector3[] _vertices;
	private MeshFilter _filter;
	void Awake () {
		_filter = GetComponent<MeshFilter>();
		GenerateVertices ();
		GenerateTriangles ();
	}

	void GenerateVertices() {
		_vertices = new Vector3[getNumVerts()];
		_filter.name = "Procedural Cube";

		int vertIndex = 0;

		for (int y = 0; y <= ySize; y++) {
			for (int x = 0; x <= xSize; x++) {
				_vertices [vertIndex++] = new Vector3 (x, y, 0);
			}
			for (int z = 1; z <= zSize; z++) {
				_vertices [vertIndex++] = new Vector3 (xSize, y, z);
			}
				
			for (int x = xSize - 1; x >= 0; x--) {
				_vertices [vertIndex++] = new Vector3 (x, y, zSize);
			}

			for (int z = zSize - 1; z > 0 ; z--) {
				_vertices [vertIndex++] = new Vector3 (0, y, z);
			}
		}

		for (int z = 1; z < zSize; z++) {
			for (int x = 1; x < xSize; x++) {
				_vertices [vertIndex++] = new Vector3 (x, ySize, z);
			}	
		}

		for (int z = 1; z < zSize; z++) {
			for (int x = 1; x < xSize; x++) {
				_vertices [vertIndex++] = new Vector3 (x, 0, z);
			}	
		}

		_filter.mesh.vertices = _vertices;
	}

	void GenerateTriangles () {
		int[] triangles = new int[getNumTriangles ()];

		int vertInRing = 2 * (xSize + zSize);
		int triangleIndex = 0;
		int vertIndex = 0;
		for (int y = 0; y < ySize; y++) {
			for (int quadNum = 0; quadNum < vertInRing - 1; quadNum++) {
				GenerateQuadTriangles (triangles, ref triangleIndex,
					vertIndex,
					vertIndex + 1,
					vertIndex + vertInRing,
					vertIndex + vertInRing + 1);
				vertIndex++;
			}
			GenerateQuadTriangles (triangles, ref triangleIndex,
				vertIndex,
				vertIndex - vertInRing + 1,
				vertIndex + vertInRing,
				vertIndex + 1);
			vertIndex++;
		}

		_filter.mesh.triangles = triangles;
	}

	void GenerateQuadTriangles(int[] triangles, ref int index, int lowerLeft, int lowerRight, int upperLeft, int upperRight) {
		triangles [index++] = lowerLeft;
		triangles [index++] = upperLeft;
		triangles [index++] = lowerRight;
		triangles [index++] = lowerRight;
		triangles [index++] = upperLeft;
		triangles [index++] = upperRight;
	}

	int getNumVerts () {
		int numCornerVert = 8;
		int numEdgeVert = 4 * (xSize + ySize + zSize - 3);
		int numInnerVert = 2 * ((xSize - 1) * (ySize - 1) +
			(xSize - 1) * (zSize - 1) +
			(ySize - 1) * (zSize - 1));

		return numCornerVert + numEdgeVert + numInnerVert;
	}
	int getNumTriangles () {
		return 6 * 2 * (xSize * ySize + zSize * ySize + xSize * zSize);
	}

	void OnDrawGizmos () {
		if (_vertices == null) {
			return;
		}
		Gizmos.color = Color.black;

		for(int index = 0; index < _vertices.Length; index++) {
			Gizmos.DrawSphere(transform.TransformPoint(_vertices[index]), 0.1f);
		}
	}
}

