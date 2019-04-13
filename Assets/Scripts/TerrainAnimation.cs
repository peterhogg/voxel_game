using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class TerrainAnimation : MonoBehaviour {
	public Animation animation;

	void onAwake(){
		animation = GetComponent<Animation> ();
		Debug.Log ("Object creted!");
	}

	// Use this for initialization
	void onDestroy () {
		Debug.Log ("OnDestroy triggered");
		animation.Play ();

	
	}
}
