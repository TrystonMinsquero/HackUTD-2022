using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
	[SerializeField] private bool _requireLogin;
	public User user;
	
	public GameObject navbar;
	public GameObject[] screens;
	
    void Start()
    {
	    Application.targetFrameRate = 60;
	    
	    if (_requireLogin) ChangeTab(0);
    }
	
	public void ChangeTab(int index) {
		for (int i = 0; i < screens.Length; i++) {
			screens[i].SetActive(i == index);
		}
		navbar.SetActive(index != 0);
	}
}
