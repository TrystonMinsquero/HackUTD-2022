using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
	[SerializeField] private CanvasGroup _mainMenu;
	[SerializeField] private List<GameObject> _mainMenuSelected;
	[SerializeField] private CanvasGroup _settings;
	[SerializeField] private List<GameObject> _settingsSelected;
	[SerializeField] private CanvasGroup _quit;
	[SerializeField] private GameObject _quitSelected;
	
	private void Start()
	{
		OpenMainMenu(0);
	}
	
	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}
	
	public void QuitGame()
	{
		Application.Quit();
		
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
	
	[Button]
	private void OpenMainMenu() => OpenMainMenu(0);
	[Button]
	private void OpenSettings() => OpenSettings(0);
	
	public void OpenMainMenu(int obj) => OpenMenu(obj, 0);
	public void OpenSettings(int obj) => OpenMenu(obj, 1);
	[Button]
	public void OpenQuit()
	{
		ActivateGroup(_quit, true);
		SetSelected(_quitSelected);
	}
	
	private void OpenMenu(int obj, int menu)
	{
		ActivateGroup(_mainMenu, menu == 0);
		if (menu == 0) SetSelected(_mainMenuSelected, obj);
		ActivateGroup(_settings, menu == 1);
		if (menu == 1) SetSelected(_settingsSelected, obj);
		ActivateGroup(_quit, false);
	}
	
	private void ActivateGroup(CanvasGroup group, bool active)
	{
		group.alpha = active ? 1 : 0;
		group.blocksRaycasts = active;
		group.interactable = active;
	}
	
	private void SetSelected(List<GameObject> objs, int obj)
	{
		if (objs.Count == 0) return;
		if (obj >= objs.Count) obj = 0;
		SetSelected(objs[obj]);
	}
	
	private void SetSelected(GameObject obj)
	{
		if (EventSystem.current) EventSystem.current.SetSelectedGameObject(obj);
	}
}
