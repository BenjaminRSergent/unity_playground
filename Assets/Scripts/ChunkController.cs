using UnityEngine;
using System.Collections;

public class ChunkController : MonoBehaviour {
	public GameObject chunkPrefab;

	public int areaAroundPlayer = 1;

	private Transform _player;
	private ChunkDatabase _chunkDb;
	private Vector2 _lastKey = Vector2.zero;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player").transform;
		_chunkDb = new ChunkDatabase ((int)chunkPrefab.transform.lossyScale.x);
		CreateChunksAround (_lastKey);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currKey = _chunkDb.GetKeyForLocation (_player.position);
		Debug.Log ("currKey is " + currKey);
		if (currKey != _lastKey) {
			UpdateBasedOnNewKey (currKey);
		}
	}

	void UpdateBasedOnNewKey (Vector2 currKey) {
		DisableChunksAround (_lastKey);
		CreateChunksAround (currKey);
		_lastKey = currKey;
	}

	void CreateChunksAround(Vector2 key) {
		for (int x = (int)key.x - areaAroundPlayer; x < (int)key.x + areaAroundPlayer+1; x++) {
			for (int y = (int)key.y - areaAroundPlayer; y < (int)key.y + areaAroundPlayer+1; y++) {
				Vector2 creationKey = new Vector2 (x, y);
				if (_chunkDb.IsChunkCreatedForKey (creationKey)) {
					_chunkDb.ChangeChunkStateAt (creationKey, true);
				} else {
					_chunkDb.AddNewChunk (creationKey, Instantiate (chunkPrefab) as GameObject);
				}
			}	
		}
	}

	void DisableChunksAround(Vector2 key) {
		for (int x = (int)key.x - areaAroundPlayer; x < (int)key.x + areaAroundPlayer+1; x++) {
			for (int y = (int)key.y - areaAroundPlayer; y < (int)key.y + areaAroundPlayer+1; y++) {
				Vector2 creationKey = new Vector2 (x, y);
				if (_chunkDb.IsChunkCreatedForKey (creationKey)) {
					_chunkDb.ChangeChunkStateAt (creationKey, false);
				} 
			}	
		}
	}
}
