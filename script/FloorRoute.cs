using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorRoute : Singleton<FloorRoute> {

	public Camera m_camMain;

	public int m_iIndex;
	public int m_iMoveRest;

	public StageParam m_stageParam;

	public void SetIndexPosition(int _iIndex)
	{
		m_iIndex = _iIndex;
		StageParam param = DataManager.Instance.stage.list[_iIndex];
		m_stageParam = param;

		//Debug.LogError(_iIndex);
		//Debug.LogError(param.pz);
		iTween.MoveTo(m_camMain.gameObject,
			iTween.Hash(
				"time", 0.65f,
				"islocal", true,
				"x", param.px,
				"y", param.py,
				"z", param.pz
			)
		);
		iTween.RotateTo(m_camMain.gameObject,
			iTween.Hash(
				"time", 0.65f,
				"islocal", true,
				"x", param.rx,
				"y", param.ry,
				"z", param.rz
			)
		);


	}
	public void MoveStart(int _iNum)
	{
		m_iMoveRest = _iNum;
		moveCheck();
	}
	private void move( int _iTargetIndex)
	{
		StageParam param = DataManager.Instance.stage.list[_iTargetIndex];
		m_stageParam = param;
		iTween.MoveTo(m_camMain.gameObject,
			iTween.Hash(
				"time", 0.65f,
				"islocal", true,
				"x", param.px,
				"y", param.py,
				"z", param.pz,
				"oncomplete", "moveEnd",
				"oncompletetarget", gameObject
			)
		);
	}

	private void moveCheck()
	{
		if (0 < m_iMoveRest)
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

	private void turn(StageParam _param)
	{
		iTween.RotateTo(m_camMain.gameObject,
			iTween.Hash(
				"time", 0.65f,
				"islocal", true,
				"x", _param.rx,
				"y", _param.ry,
				"z", _param.rz
			)
		);
	}

	private void moveEnd()
	{
		turn(m_stageParam);
		moveCheck();			
	}


	public UnityEvent OnMoveFinished = new UnityEvent();

	private void moveFinished()
	{
		//Debug.LogError("moveFinished");
		OnMoveFinished.Invoke();
	}

	
	
	// Update is called once per frame
	void Update () {
		
	}
}
