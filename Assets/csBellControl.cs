using UnityEngine;
using System.Collections;

public class csBellControl : MonoBehaviour {
	float mousePreviousX = 0;
	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	if(Input.GetMouseButton(0)) {

			transform.Rotate(new Vector3(0,-(Input.mousePosition.x-mousePreviousX),0));

		}
	
		mousePreviousX = Input.mousePosition.x;

	}
}
