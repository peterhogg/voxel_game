using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainSpawner : MonoBehaviour {
	[SerializeField] GameObject terrain;
	[SerializeField] GameObject baseBlock;
	[SerializeField] int x = 50;
	[SerializeField] int y = 50;
	[SerializeField] int z = 5;
	// Use this for initialization
	void Start () {
		Dictionary<int, GameObject> blockMap = new Dictionary<int,GameObject>();
		blockMap.Add (1, baseBlock);
		blockMap.Add (2, terrain);

		int[,,] map = new int[x*2,y*2,z];

		// generate the first quadrent
		for(int i = 0; i < x; i ++){
			for(int j = 0; j < y; j++){
				float height = Mathf.Clamp(Mathf.PerlinNoise((float) i/x, (float)j/ y) * z,1,z);
				for (int k = 0; k < height; k++) {
					if (k == 0) {
						Instantiate(baseBlock).transform.localPosition = new Vector3 (i, -z + k, j );
						Instantiate(baseBlock).transform.localPosition = new Vector3((2*x - 1) - i, -z + k, (2 * y - 1) - j);
						Instantiate(baseBlock).transform.localPosition = new Vector3((2 * x - 1) - i, -z + k, j);
						Instantiate(baseBlock).transform.localPosition = new Vector3(i, -z + k, (2 * y - 1) - j);

					} else {
						Instantiate(terrain).transform.localPosition = new Vector3(i, -z + k, j); 
						Instantiate(terrain).transform.localPosition = new Vector3((2 * x - 1) - i, -z + k, (2 * y - 1) - j);
						Instantiate(terrain).transform.localPosition = new Vector3((2 * x - 1) - i, -z + k, j);
						Instantiate(terrain).transform.localPosition = new Vector3(i, -z + k, (2 * y - 1) - j);

					}

				}

			}
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
