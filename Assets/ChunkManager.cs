using UnityEngine;
using System.Collections;

public class ChunkManager : MonoBehaviour {
	public GameObject chunkPrefab;


	private float chunkSize;
	private Transform _player;
	private GameObject[,] loadedChunks = new GameObject[3,3];

	// Use this for initialization
	void Start () {
		// Chunk is assumed to be square
		chunkSize = chunkPrefab.transform.lossyScale.x;
		_player = GameObject.FindGameObjectWithTag ("Player").transform;
		Init ();
	}

	void Init() {
		for (int x = 0; x < 3; x++) {
			for (int y = 0; y < 3; y++) {
				int offsetX = x - 1;
				int offsetZ = y - 1;
				GameObject newChunk = CreateChunkAt (new Vector3(offsetX * chunkSize, 0, offsetZ * chunkSize));

				loadedChunks [x, y] = newChunk;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	GameObject CreateChunkAt (Vector3 position)	{
		return Instantiate (chunkPrefab, position, Quaternion.identity) as GameObject;
	}
}
