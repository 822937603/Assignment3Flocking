using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RightClicking : SelectionController {

	public float distance = 5;

	private NavMeshAgent agent;
	private Vector3 targetLocation = Vector3.zero;
	private bool checkedselected = false;
	private bool is_active = false;

	public override void deSelect(){
		checkedselected = false;
	}

	public override void Select(){
		checkedselected = true;
	}

	public void moveToTarget(){
		agent.SetDestination (targetLocation);
		agent.Resume ();
		is_active = true;
	}

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (checkedselected && Input.GetMouseButtonDown (1)) {
			var target = FlockingController.current.pointToMap (Input.mousePosition);
			if (target.HasValue) {
				targetLocation = target.Value;
				moveToTarget ();
			}
		}
		if (is_active && Vector3.Distance (targetLocation, transform.position) < distance) {
			agent.Stop ();
			is_active = false;
		}
	}
}
