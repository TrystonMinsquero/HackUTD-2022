using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
	public UI_Catalog catalog;
	public UI_Club clubViewer;
	
	public GameObject[] screens;
	
    // Start is called before the first frame update
    void Start()
    {
	    Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void Open(ClubObject club) {
		clubViewer.attachedClub = club;
		clubViewer.open();
	}
	
	public void Close() {
		clubViewer.close();
	}
	
	public void ChangeTab(int index) {
		for (int i = 0; i < screens.Length; i++) {
			screens[i].SetActive(i == index);
		}
	}
}
