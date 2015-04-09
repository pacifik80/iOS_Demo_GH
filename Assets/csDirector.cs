using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class csDirector : MonoBehaviour
{

	public GameObject target;
	public GameObject txt;
	public GameObject fader;
	public GameObject txtResult;
	public GameObject valResult;
	public GameObject txtCount;

	enum LevelState
	{
		Init,
		PreAnnounce,
		Run,
		Results
	}

	LevelState curState = LevelState.Init;
	bool prevTouch = false;
	bool actTouch = false;
	bool click = false;
	float maxAngle = Mathf.PI / 2;
	float result = 0.0f;
	float round = Mathf.PI * 2.0f;
	float bestRes = 0.0f;
	int bestScore = 0;
	int score = 0;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckInputs ();
	
		if (curState == LevelState.Init) {
			PhaseInit ();
			curState = LevelState.PreAnnounce;
		} else 
		if (curState == LevelState.PreAnnounce) {
		
			if (click) {

				txt.SetActive (false);

				target.GetComponent<csTargetControl> ().runTarget = true;
				target.GetComponent<csTargetControl> ().currentAngle = 0.0f;

				curState = LevelState.Run;
			}
		} else 
		if (curState == LevelState.Run) {

			float curAng = target.GetComponent<csTargetControl> ().currentAngle;

			float runAngle = Mathf.Clamp (curAng, round, round + maxAngle) - round;
			float fade = runAngle / maxAngle;

			if (curAng < round) {
				txtCount.SetActive(true);

				int n = Mathf.CeilToInt ((1 - curAng / round) * 5.0f);

				txtCount.GetComponent<Text>().text = n.ToString();

			} else {
				txtCount.SetActive(false);
			}


			Fader (fade);

			if (fade >= 1.0f) {
				if (click) {
					GuessCapture ();
					result = curAng - round;
					result = Mathf.Abs ((round - result)) / round;
					score = Mathf.CeilToInt (100.0f / result);
					txtResult.GetComponent<Text> ().text = "Score:\n" + score.ToString () + "\nResult:\n" + result.ToString ("0.000000");
					txtResult.SetActive (true);
					curState = LevelState.Results;

					if (score > bestScore) {
						bestScore = score;
					}
					if ((result < bestRes) | (bestRes == 0.0f)) {
						bestRes = result;
					}

					valResult.GetComponent<Text> ().text = bestScore.ToString () + "\n" + bestRes.ToString ();
				}
				if (curAng >= (round * 2.5f)) {
					Debug.Log (curAng.ToString () + ", " + (round * 2.5f).ToString ());
					GuessCapture ();
					result = -1.0f;
					txtResult.GetComponent<Text> ().text = "Failed !";
					txtResult.SetActive (true);
					curState = LevelState.Results;
				}
			}



		} else
		if (curState == LevelState.Results) {

			if (click) {

				target.GetComponent<csTargetControl> ().runTarget = true;
				target.GetComponent<csTargetControl> ().currentAngle = 0.0f;
				txtResult.SetActive (false);

				curState = LevelState.Run;

			}

		}
		   

	}

	void PhaseInit ()
	{
		csTargetControl csT = target.GetComponent<csTargetControl> ();
		csT.currentAngle = 0;
		csT.rotationSpeed = 2.0f;
		csT.radius = 3.0f;
		csT.scale = 0.5f;
		csT.runTarget = true;

		txt.SetActive (true);
		txtResult.SetActive (false);
	}

	void CheckInputs ()
	{
		bool t = false;

		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				t = true;
			}
		}

		bool m = Input.GetMouseButton (0);
		
		prevTouch = actTouch;
		
		if (t || m) {
			actTouch = true;
		} else {
			actTouch = false;
		}
		
		if ((actTouch == true) & (prevTouch == false)) {
			click = true;
		} else {
			click = false;
		}
	}

	void Fader (float f)
	{
		fader.GetComponent<Image> ().color = new Color (f, f, f, f);
	}

	void GuessCapture ()
	{
		target.GetComponent<csTargetControl> ().runTarget = false;
		fader.GetComponent<Image> ().color = new Color (1.0f, 1.0f, 1.0f, 0.0f);

	}
}
