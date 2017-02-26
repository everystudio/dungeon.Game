using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetPosition : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Debug.LogError(string.Format("{0}:p={1} lp={2}", gameObject.name, gameObject.transform.position, gameObject.transform.localPosition));		
	}
}
