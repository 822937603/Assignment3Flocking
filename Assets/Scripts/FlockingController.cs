using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingController : MonoBehaviour {

	public static FlockingController current;

	public MeshCollider collider;

	public Vector3? pointToMap(Vector2 point){
		var ray = Camera.main.ScreenPointToRay (point);
		RaycastHit gothit;
		if (!collider.Raycast (ray, out gothit, Mathf.Infinity)) {
			return null;
		}
		return gothit.point;
	}

	// Use this for initialization
	void Start () {
		current = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
