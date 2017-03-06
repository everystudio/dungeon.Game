using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class IconPlayer : MonoBehaviour {

	[SerializeField]
	private Image m_imgIcon;

	[SerializeField]
	private GameObject m_goLock;

	public PlayerMasterParam masterParam;
	public PlayerParam playerParam;

	public Button btn
	{
		get
		{
			if( m_btn == null)
			{
				m_btn = gameObject.GetComponent<Button>();
			}
			return m_btn;
		}
	}
	private Button m_btn = null;

	public void Initialize( PlayerMasterParam _masterParam)
	{
		masterParam = _masterParam;

		m_imgIcon.sprite = SpriteManager.Instance.LoadSprite(PlayerMaster.GetIconFilename(masterParam.player_id));

		btn.onClick.AddListener(OnClick);
	}

	public EventIconPlayer OnEventIconPlayer = new EventIconPlayer();
	private void OnClick()
	{
		OnEventIconPlayer.Invoke(this);
	}

}
