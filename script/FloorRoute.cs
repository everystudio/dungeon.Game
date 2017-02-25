﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRoute : Singleton<FloorRoute> {

	public Camera m_camMain;
	public GameObject[] m_goRouteArr;

	public int m_iIndex;
	public int m_iMoveRest;

	void Start()
	{
		m_iIndex = 0;
	}

	public void MoveStart(int _iNum)
	{
		m_iMoveRest = _iNum;
		moveEnd();
	}
	private void move( int _iTargetIndex)
	{
		/*
		iTween.MoveTo(m_camMain.gameObject,
			iTween.Hash(
				"time", 0.65f,
				"islocal", true,
				"x", m_goRouteArr[_iTargetIndex].transform.localPosition.x,
				"z", m_goRouteArr[_iTargetIndex].transform.localPosition.z,
				"oncomplete", "moveEnd",
				"oncompletetarget", gameObject
			)
		);
		*/
		iTween.MoveTo(m_camMain.gameObject,
			iTween.Hash(
				"time", 0.65f,
				"islocal", true,
				"x", DataManager.Instance.stage.list[m_iIndex].px,
				"y", DataManager.Instance.stage.list[m_iIndex].py,
				"z", DataManager.Instance.stage.list[m_iIndex].pz,
				"oncomplete", "moveEnd",
				"oncompletetarget", gameObject
			)
		);

	}

	private void moveEnd()
	{
		Debug.LogError(string.Format("index:{0} rest:{1}", m_iIndex, m_iMoveRest));

		if ( 0 < m_iMoveRest )
		{
			m_iIndex = DataManager.Instance.stage.list[m_iIndex].next_id;
			m_iMoveRest -= 1;
			move(m_iIndex);
		}
		else
		{
			moveFinished();
		}
	}

	private void moveFinished()
	{
		//Debug.LogError("moveFinished");
	}

	
	
	// Update is called once per frame
	void Update () {
		
	}
}
