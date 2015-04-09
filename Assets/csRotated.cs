using UnityEngine;
using System.Collections;

public class csRotated : MonoBehaviour
{

	private float radius = 3.18f;
	private float angSpeed = 1.0f;
	public float angPos = 0.0f;
	public float centerX = 0;
	public float centerY = 3.0f;
	bool paused = true;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!paused) {
			UpdatePosition ();
			DrawPosition ();
		}

	}

	public void Reset ()
	{
		angPos = 0.0f;
		angSpeed = 1.0f;
		Pause ();
		DrawPosition ();
	}

	public void Run ()
	{
		paused = false;
	}

	public void Pause ()
	{
		paused = true;
	}

	public void UpdatePosition() {
		angPos += angSpeed * Time.fixedDeltaTime;
	}

	public void DrawPosition ()
	{

		
		float bX = Mathf.Sin (angPos) * radius;
		float bY = Mathf.Cos (angPos) * radius;
		
		transform.position = new Vector3 (centerX + bX, centerY + bY, 0);
	}
}
