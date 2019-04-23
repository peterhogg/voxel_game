using UnityEngine;
using System.Collections;

public class DetectSelected : MonoBehaviour {
	public Camera camera;
	public GameObject selectedBlock;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = this.camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

		if (Physics.Raycast(ray, out hit, 10.0f)) {
			Transform objectHit = hit.transform;
			//Destroy block on right click
			if (Input.GetMouseButtonDown (1)) {
				if(objectHit.gameObject.tag != "base"){
					Destroy (objectHit.gameObject);
				}
			}
			//Create block on left click
			if (Input.GetMouseButtonDown (0)) {
				Vector3 postiion = new Vector3 (Mathf.Floor (objectHit.position.x), Mathf.Floor (objectHit.position.y), Mathf.Floor (objectHit.position.z)) + hit.normal;
				if (!(Physics.CheckSphere (postiion, 0.125f))) {
					GameObject spawn = Instantiate<GameObject> (selectedBlock);
					spawn.transform.localPosition = postiion;

				}

			}
				
			// Do something with the object that was hit by the raycast.
		}	
	
	}
}
