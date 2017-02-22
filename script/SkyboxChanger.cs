using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour {

	[SerializeField]
	Material m_matForest;

	// Use this for initialization
	void Start () {
		RenderSettings.skybox = m_matForest;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
