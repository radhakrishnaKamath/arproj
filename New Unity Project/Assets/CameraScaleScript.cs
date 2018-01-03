using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaleScript : MonoBehaviour {

	private float curDistance;
	public Transform distantPlanet;

	public float minimumDistance;
	public float maximumDistance;

	public float minimumDistanceScale;
	public float maximumDistanceScale;

	void Start()
	{
		
	}
		
	void Update() {
		var distance = (transform.position - Camera.main.transform.position).magnitude;
		var norm = (distance - minimumDistance) / (maximumDistance - minimumDistance);
		norm = Mathf.Clamp01(norm);

		var minScale = Vector3.one * maximumDistanceScale;
		var maxScale = Vector3.one * minimumDistanceScale;

		transform.localScale = Vector3.Lerp(maxScale, minScale, norm);
	}
}
