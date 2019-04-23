using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmptySpawner : MonoBehaviour {
	public GameObject terrain;
	public GameObject baseBlock;
	public int x;
	public int y;
	public int z;
	// Use this for initialization
	void Start() {
		Dictionary<int, GameObject> blockMap = new Dictionary<int, GameObject>();
		blockMap.Add(1, baseBlock);
		blockMap.Add(2, terrain);

		int[,,] map = new int[x, z, y];

		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				for (int k = 0; k < z; k++) {
					if (k == 0) {
						map[i, k, j] = 1;
						GameObject spawn2 = Instantiate<GameObject>(baseBlock);
						spawn2.transform.localPosition = new Vector3(i, -z + k, j);
					} 
				}

			}
		}

	}

	// Update is called once per frame
	void Update() {

	}
}
