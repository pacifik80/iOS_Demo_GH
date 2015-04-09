using UnityEngine;
using System.Collections;

public class csLabelControl : MonoBehaviour {

	public GameObject goReady;
	public GameObject goGo;

	bool goVisible = false;
	float goLifeTime = 0.0f;
	float goLifeLimit = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		ProcessGo ();
	
	}

	public void ShowReady ()
	{
		goReady.SetActive (true);
	}

	public void HideReady ()
	{
		goReady.SetActive (false);
	}

	void ProcessGo () {
		if (goVisible) {
			goLifeTime += Time.deltaTime;

			goGo.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,1.0f - (goLifeTime/goLifeLimit));

			if(goLifeTime >= goLifeLimit) {
				goVisible = false;
				goGo.SetActive(false);
			}
		}
	}

	public void ShowGoShort() {

		goGo.SetActive (true);
		goVisible = true;
		goLifeTime = 0.0f;
	}
}
