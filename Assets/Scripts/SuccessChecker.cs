using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessChecker : MonoBehaviour {

	void OnTriggerEnter(){
		GameManager.Instance.SuccessPopped = true;
	}
}
