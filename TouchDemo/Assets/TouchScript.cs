using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchScript : MonoBehaviour {

	private GameObject distanceTextObject;
	public float speed = 0.1F;
	public GameObject particle;

	// Use this for initialization
	void Start () {
		//distanceTextObject = GameObject.FindGameObjectWithTag ("TouchCoord");
		StartCoroutine ("Move");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * 3f * Time.deltaTime);
		/*if (Input.touchCount > 0)
		{
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).position;
			distanceTextObject.GetComponent<Text> ().text = "Touch Coord: " + touchDeltaPosition.x + " " + touchDeltaPosition.y;
			for (int i = 0; i < Input.touchCount; ++i)
			{
				if (Input.GetTouch(i).phase == TouchPhase.Began)
				{
					// Construct a ray from the current touch coordinates
					Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

					// Create a particle if hit
					if (Physics.Raycast(ray))
						Instantiate(particle, transform.position, transform.rotation);
				}
			}
		}*/
	}

	IEnumerator Move() {


		while (true) {
			yield return new WaitForSeconds (3.5f);
			transform.eulerAngles += new Vector3 (0, 180f, 0);
		}
	}
}
