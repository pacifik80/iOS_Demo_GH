using UnityEngine;
using System.Collections;

public class cs_v3_arrows_control : MonoBehaviour
{

	public GameObject big_arrow;
	public GameObject small_arrow;
	private bool paused = false;
	float passedTime = 0.0f;
	bool hiding = false;
	float hideLifeTime = 0.0f;
	float hideLifeLimit = 1.5f;

	// Use this for initialization
	void Start ()
	{



	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!paused) {

			passedTime += Time.fixedDeltaTime;
	
		}
	}

	void Update ()
	{
		if (!paused) {

			big_arrow.transform.localRotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, - (passedTime * 360.0f) / 5.0f));
			small_arrow.transform.localRotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, - passedTime * 360.0f));
		}

		ProcessHiding ();
	}

	void Pause ()
	{
	
		paused = true;
	}

	void Resume ()
	{

		paused = false;
	}

	void Reset ()
	{
		passedTime = 0.0f;
		Pause ();
		SetArrowsTransparency (0.0f);
	}

	void SetArrowsTransparency (float f)
	{
		small_arrow.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 1 - f);
		big_arrow.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 1 - f);
	}

	public void ShowArrows () {
		SetArrowsTransparency (0.0f);
	}

	public void StartArrowsHiding ()
	{
		hiding = true;
		hideLifeTime = 0.0f;
	}

	void ProcessHiding ()
	{
		if (hiding) {
			hideLifeTime += Time.deltaTime;
			SetArrowsTransparency (hideLifeTime / hideLifeLimit);

			Debug.Log ("Hiding ...");

			if(hideLifeTime >= hideLifeLimit) {

				hiding = false;
			}
		}
	}
}
