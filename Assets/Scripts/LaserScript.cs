using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public Sprite laserOnSprite;
	public Sprite laserOffSprite;

	public float intervalMinTime = 0.5f;
	public float intervalMaxTime = 2;
	public float rotationSpeed = 0.1f;

	private float rotationmultiplier = 1;
	private float interval = 0.5f;

	private bool isLaserOn = true;
	private bool ToggleOn = true;
	private float timeUntilNextToggle;
	private bool laserRotate = false;

	void Start () {
		interval = timeUntilNextToggle = Random.Range(intervalMinTime, intervalMaxTime);
		laserRotate = Random.Range(-100, 100) > 0;
		if (!laserRotate)
			rotationmultiplier = 0;
		else
			rotationmultiplier = 1;
		ToggleOn = Random.Range(-100, 100) > 0;
		if (!ToggleOn)
			rotationmultiplier = 0;
		else
			rotationmultiplier = 1;

	}

	void FixedUpdate()
	{
		if (ToggleOn) {
			timeUntilNextToggle -= Time.fixedDeltaTime;
			if (timeUntilNextToggle <= 0) {
				isLaserOn = !isLaserOn;
				GetComponent<Collider2D>().enabled = isLaserOn;
				SpriteRenderer spriteRenderer = ((SpriteRenderer)GetComponent<Renderer>());
				if (isLaserOn) {
					spriteRenderer.sprite = laserOnSprite;
				} else {
					spriteRenderer.sprite = laserOffSprite;
				}

				timeUntilNextToggle = interval;
			}
		}
		transform.RotateAround(transform.position, Vector3.forward, rotationmultiplier * rotationSpeed * Time.fixedDeltaTime);
	}
}
