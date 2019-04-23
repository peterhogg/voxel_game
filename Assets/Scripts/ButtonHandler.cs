using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonHandler : MonoBehaviour {
	//Make sure to attach these Buttons in the Inspector
	public Button randomButton;
	public Button emptyButton;

	void Start() {
		emptyButton.onClick.AddListener(loadEmpty);
		randomButton.onClick.AddListener(loadRandom);
	}

	void loadEmpty() {
		Application.LoadLevel("Empty");
	}

	void loadRandom() {
		Application.LoadLevel("Random");
	}
}