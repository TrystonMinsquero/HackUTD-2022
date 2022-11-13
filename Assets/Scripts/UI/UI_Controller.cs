using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	    CheckClubAdmin();
    }

    public void CheckClubAdmin() => navbar.transform.Find("Club Admin").gameObject.SetActive(user.ownClub != null);
	
	public void ChangeTab(int index) {
		for (int i = 0; i < screens.Length; i++) {
			screens[i].SetActive(i == index);
		}
		navbar.SetActive(index != 0);
	}
}
