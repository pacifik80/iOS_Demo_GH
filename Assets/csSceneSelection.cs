using UnityEngine;
using System.Collections;

public class csSceneSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Load01 () {
		Application.LoadLevel ("circle02"); 
	}
	public void Load02 () {
		Application.LoadLevel ("v2"); 
	}
	public void Load03 () {
		Application.LoadLevel ("v3"); 
	}
	public void Load04 () {
		Application.LoadLevel ("v4"); 
	}
	public void Load05 () {
		Application.LoadLevel ("v5_flat"); 
	}
	public void Load06 () {
		Application.LoadLevel ("v6_flat"); 
	}
}
