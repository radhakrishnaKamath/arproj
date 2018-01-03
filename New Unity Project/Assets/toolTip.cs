using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toolTip : MonoBehaviour {

	GameObject ttp;
	GameObject ttp1;
	GameObject ttp2;
	GameObject ttp3;
	bool init = false;
	public Button fireButton;

	// Use this for initialization
	void Start () {
		fireButton.onClick.AddListener (OnButtonDown);
	}

	void OnButtonDown () {
		if (!init) {
			//ttp = Instantiate (Resources.Load ("Tooltip_GO", typeof(GameObject))) as GameObject;
			init = true;
			print ("Initialized");
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Destroy (ttp);
			print ("Destroyed");
			init = false;
		}
	}
}


