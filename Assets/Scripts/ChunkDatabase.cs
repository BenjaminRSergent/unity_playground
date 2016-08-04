using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ChunkDatabase {
	private Dictionary<Vector2, GameObject> _chunks = new Dictionary<Vector2, GameObject>();
	private int _chunkSize;

	public ChunkDatabase(int chunkSize) {
		_chunkSize = chunkSize;
	}

	public Vector2 GetKeyForLocation(Vector3 location) {
		return new Vector2 (location.x / _chunkSize, location.z / _chunkSize);
	}

	public bool IsChunkCreatedForKey(Vector2 key) {
		return _chunks.ContainsKey (key);
	}

	public void AddNewChunk(Vector2 key, GameObject chunk) {
		if(IsChunkCreatedForKey(key)) {
			Debug.LogWarning ("Added a chunk to a key that already exists " + key);
			GameObject.Destroy(_chunks[key]);
		}
		Vector2 xzPos = key * _chunkSize;

		chunk.transform.position = new Vector3 (xzPos.x, 0, xzPos.y);
		chunk.transform.rotation = Quaternion.identity;
		Debug.Log ("Added a chunk at location " + chunk.transform.position);
		_chunks[key] = chunk;
	}

	public void ChangeChunkStateAt(Vector2 key, bool isActive) {
		if (!IsChunkCreatedForKey (key)) {
			throw new Exception ("Attempted to disable non-existant chunk");
		}

		_chunks [key].SetActive (isActive);
	}
}

