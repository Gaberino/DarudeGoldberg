using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour {


	public Color initialButtonColor;
	public Color activatedButtonColor;

	public Rigidbody cannonBall;
	public float cannonForce;

	private MeshRenderer myRenderer;
	// Use this for initialization
	void Start () {
		myRenderer = this.GetComponent<MeshRenderer>();
		myRenderer.material.color = initialButtonColor;
	}

	void OnCollisionEnter(Collision col){
		if (col.collider.name == "SlidyCube (2)"){
			myRenderer.material.color = activatedButtonColor;
			cannonBall.AddRelativeForce(0, 0, cannonForce, ForceMode.Impulse);
		}
	}
}
