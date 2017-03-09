using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using GoogleMobileAds.Api;

public class AdsManager : Singleton<AdsManager>
{
	private AdsBanner m_adsBannerGameBottom;

	void loadedScene(Scene scenename, LoadSceneMode SceneMode)
	{
		Debug.LogError("今のSceneの名前 = " + scenename.name);
		setup(scenename.name);
	}
	public override void Initialize()
	{
		m_adsBannerGameBottom = null;
		//Debug.LogError(SceneManager.GetActiveScene().name);
		SceneManager.sceneLoaded += loadedScene;
		Debug.LogError("AdsManager.Initialize");

	}

	public void OnSkitStarted()
	{
		ShowBanner(false);
	}

	public void OnSkitFinished()
	{
		ShowBanner(true);
	}

	private void cleanup()
	{
		if (m_adsBannerGameBottom != null)
		{
			Destroy(m_adsBannerGameBottom);
			m_adsBannerGameBottom = null;
		}
	}

	private void setup(string _strSceneName)
	{
		cleanup();
		switch (_strSceneName)
		{
			case "Command":
			default:
				if (m_adsBannerGameBottom == null)
				{
					m_adsBannerGameBottom = gameObject.AddComponent<AdsBanner>();
				}
				break;
		}
	}

	public void ShowBanner(bool _bFlag)
	{
		if( m_adsBannerGameBottom == null)
		{
			return;
		}
		m_adsBannerGameBottom.Show(_bFlag);
	}
}

