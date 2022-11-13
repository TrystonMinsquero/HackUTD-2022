using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event : MonoBehaviour
{
	public TextMeshProUGUI nameText, clubText, dateText, timeText, descText, locationText;
	public GameObject promoted;
	
	public void SetEvent(string name, string club, string date, string time, string desc, string location, bool promoted = false) {
		nameText.text = name;
		clubText.text = club;
		dateText.text = date;
		timeText.text = time; 
		descText.text = desc;
		locationText.text = location;
		this.promoted.SetActive(promoted);
	}
}
