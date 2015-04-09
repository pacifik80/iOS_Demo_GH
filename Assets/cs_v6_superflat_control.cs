using UnityEngine;
using System.Collections;

public class cs_v6_superflat_control : MonoBehaviour
{

	public GameObject circle;
	private BuildCircleMesh c_control;
	private MeshRenderer c_ren;
	private Material c_mat;

	private bool paused = false;
	float passedTime = 0.0f;
	bool hiding = false;
	float hideLifeTime = 0.0f;
	float hideLifeLimit = 1.5f;

	float TurnTime = 5.0f;

	// Use this for initialization
	void Start ()
	{
		c_control = circle.GetComponent<BuildCircleMesh> ();

		c_ren = circle.GetComponent<MeshRenderer> ();

		c_mat = c_ren.material;




	
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
		//paused = false;
		if (!paused) {

			float tBeg = 0.0f;
			float tEnd = 0.0f;

			//float turn = (Mathf.Repeat(passedTime, 2 * Mathf.PI) * 360.0f) / Mathf.PI;

			if(Mathf.Repeat(passedTime, 2 * TurnTime) <= TurnTime) {
				tBeg = 0.0f;
				tEnd = Mathf.Repeat (passedTime, TurnTime) * 360.0f / TurnTime;
			} else {
				tBeg = Mathf.Repeat (passedTime, TurnTime) * 360.0f / TurnTime;
				tEnd = 360.0f;

			}

			c_control.startAngle = tBeg;
			c_control.endAngle = tEnd;

			//big_arrow.transform.localRotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, - (passedTime * 360.0f) / 5.0f));
			//small_arrow.transform.localRotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, - passedTime * 360.0f));
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
		passedTime = TurnTime;
		Pause ();
		SetArrowsTransparency (0.0f);
	}

	void SetArrowsTransparency (float f)
	{

		c_mat.SetColor("_Color", new Color (10.0f/255.0f, 176.0f/255.0f, 39.0f/255.0f, 1 - f));
		//small_arrow.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 1 - f);
		//big_arrow.GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f, 1 - f);
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
