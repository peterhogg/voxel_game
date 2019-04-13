using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainSpawner : MonoBehaviour {
	public GameObject terrain;
	public GameObject baseBlock;
	public int x;
	public int y;
	public int z;
	// Use this for initialization
	void Start () {
		Dictionary<int, GameObject> blockMap = new Dictionary<int,GameObject>();
		blockMap.Add (1, baseBlock);
		blockMap.Add (2, terrain);

		int[,,] map = new int[x,z,y];

		for(int i = 0; i < x; i ++){
			for(int j = 0; j < y; j++){
				for (int k = 0; k < z; k++) {
					if (k == 0) {
						map [i,k,j] = 1;
						GameObject spawn2 = Instantiate<GameObject> (baseBlock);
						spawn2.transform.localPosition = new Vector3 (i, -z + k, j);
					} else {
						//Some sort of random operator weighted to be more likely at edges
						if (Random.Range(0,z) < z - k) {
							//Only generate terrain if the block below was terrain
							if (map [i, k - 1, j] != 0 ) {
								GameObject spawn = Instantiate<GameObject> (terrain);
								spawn.transform.localPosition = new Vector3 (i, -z + k, j);
								map [i, k, j] = 2;
							}
						}
					}

				}

			}
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
