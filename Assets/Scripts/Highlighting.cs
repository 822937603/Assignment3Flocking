using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighting : SelectionController {

	public GameObject display;

	public override void deSelect ()
	{
		display.SetActive (false);
	}

	public override void Select(){
		display.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		display.SetActive (false);
	}

}
