using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {

	private List<SelectionController> selections = new List<SelectionController> ();
		
	// Update is called once per frame
	void Update () {
		if (!Input.GetMouseButtonDown (0)) {
			return;
		}
		var e = UnityEngine.EventSystems.EventSystem.current;
		if (e != null && e.IsPointerOverGameObject ()) {
			return;
		}
		if (selections.Count > 0) {
			if (!Input.GetKey (KeyCode.LeftShift) && !Input.GetKey (KeyCode.RightShift)) {
				foreach (var selection in selections) {
					if (selection != null) {
						selection.deSelect ();
					}
				}
				selections.Clear ();
			}
		}
		var camera = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit gotHit;
		if(!Physics.Raycast(camera,out gotHit)){
			return;
		}

		var interactive = gotHit.transform.GetComponent<SelectionController> ();
		if (interactive == null) {
			return;
		}
		selections.Add (interactive);
		interactive.Select ();
	}
}
