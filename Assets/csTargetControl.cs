using UnityEngine;
using System.Collections;

public class csTargetControl : MonoBehaviour
{
	public float currentAngle = 0.0f;
	public float rotationSpeed = 5.0f;
	public float radius = 4.0f;
	public float scale = 0.5f;
	public bool runTarget = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		float cx = radius * Mathf.Sin (currentAngle);
		float cy = radius * Mathf.Cos (currentAngle);

		transform.position = new Vector3 (cx, cy, 0.0f);
		transform.localScale = new Vector3 (scale, scale, scale);

		if (runTarget) {
			currentAngle += rotationSpeed * Time.deltaTime;
		}
	}
}
