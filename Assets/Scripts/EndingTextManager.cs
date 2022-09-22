using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EndingTextManager : MonoBehaviour
{
	[SerializeField] private TMP_Text textOutput;
	[SerializeField] private GameObject finA;
	[SerializeField] private GameObject finB;
	[Header("endMenu")]
	[SerializeField] private Button _replayButton;
	[SerializeField] private Button _mainMenuButton;
	[SerializeField] private TextMeshProUGUI _replay;
	[SerializeField] private TextMeshProUGUI _mainMenu;
	private GameObject _lastselect;

	void Start()
	{
		_replayButton.onClick.AddListener(ReplayGame);
		_mainMenuButton.onClick.AddListener(MenuGame);
		if (GameManager.instance.ending)
		{
			finA.SetActive(true);
			GameManager.instance.ending = false;
		}
		else
		{
			finB.SetActive(true);
		}
		EventSystem.current.firstSelectedGameObject = _replayButton.gameObject;
	}

	private void Update()
	{
		if (!EventSystem.current.currentSelectedGameObject)
		{
			EventSystem.current.SetSelectedGameObject(_replayButton.gameObject);
		}
		_replay.color = new Color(0, 242, 255);
		_mainMenu.color = new Color(0, 242, 255);
		switch (EventSystem.current.currentSelectedGameObject.name)
		{
			case "Reessayer":
				_replay.color = new Color(255, 215, 0);
				break;
			case "Menu":
				_mainMenu.color = new Color(255, 215, 0);
				break;
		}
	}

	private void OnDestroy()
	{
		_replayButton.onClick.RemoveListener(ReplayGame);
		_mainMenuButton.onClick.RemoveListener(MenuGame);
	}
	
	public void MenuGame()
	{
		SoundTracker.instance.PlayBgAmbient();
		GameManager.instance.ReturnMainMenu();
	}
	
	public void ReplayGame()
	{
		SoundTracker.instance.PlayBgAmbient();
		SoundTracker.instance.PlayBgShady();
		GameManager.instance.StartGame();
	}
}