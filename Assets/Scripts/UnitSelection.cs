using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour {

	private bool is_selected = false;
	public bool selected { get { return is_selected; } }

	public bool switchingStances = false;

	public void Select()
	{
		is_selected = true;
		foreach (var selection in GetComponents<SelectionController>()) {
			selection.Select ();
		}
	}

	public void DeSelect()
	{
		is_selected = false;
		foreach (var selection in GetComponents<SelectionController>()) {
			selection.deSelect ();
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (switchingStances) {
			switchingStances = false;
			if (is_selected) {
				DeSelect ();
			} else {
				Select ();
			}
				
		}
	}
}
