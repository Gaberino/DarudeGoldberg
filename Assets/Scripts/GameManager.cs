using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public Transform initialPositionTransform;
	public Transform startingPositionTransform;
	public float cameraTransitionSpeed = 2f;
	public float machineStartBuffer = 1f;

	public GameObject winCanvas;

	public Rigidbody firstHammerRigidbody;
	public float hammerStartForce = 20;
	public bool machineStarted = false;
	public bool cameraReadying = false;

	public bool SuccessPopped = false;

	private float currentTransitionTime = 0;
	private float currentBufferTime = 0;
	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!machineStarted) {
			if (!cameraReadying) {
				if (Input.GetKeyDown (KeyCode.Space)) {
					cameraReadying = true;
				}
			} else {
				if (currentTransitionTime < 1) {
					currentTransitionTime += Time.deltaTime / cameraTransitionSpeed;
					Camera.main.transform.position = Vector3.Lerp (initialPositionTransform.position, startingPositionTransform.position, currentTransitionTime);
					Camera.main.transform.eulerAngles = Vector3.Slerp (initialPositionTransform.eulerAngles, startingPositionTransform.eulerAngles, currentTransitionTime);
				}
				else if (currentTransitionTime >= 1) {
					Camera.main.transform.position = startingPositionTransform.position;
					Camera.main.transform.eulerAngles = startingPositionTransform.eulerAngles;
					if (currentBufferTime < machineStartBuffer) {
						currentBufferTime += Time.deltaTime;
					} else {
						firstHammerRigidbody.AddRelativeForce (0, 0, hammerStartForce, ForceMode.Impulse);
						machineStarted = true;
					}
				}
			}
		} else {
			if (SuccessPopped) {
				winCanvas.SetActive(true);
			}
		}
	}
}
