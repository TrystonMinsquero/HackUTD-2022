using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
	[SerializeField] private UI_Controller _controller;
	public TextMeshProUGUI nameText, clubText, dateText, timeText, descText, locationText;
	public GameObject promoted;
	public Button rsvpButton;
	public Button unRsvpButton;

	private EventObject _event;
	
	private void OnValidate()
	{
		if (!_controller) _controller = FindObjectOfType<UI_Controller>();
	}

	public void SetEvent(EventObject e, bool promoted = false) {
		SetEvent(e.name, e.club, e.date, e.time, e.desc, e.location, promoted);
		_event = e;
	}
	public void SetEvent(string name, string club, string date, string time, string desc, string location, bool promoted = false) {
		nameText.text = name;
		clubText.text = club;
		dateText.text = date;
		timeText.text = time; 
		descText.text = desc;
		locationText.text = location;
		this.promoted.SetActive(promoted);
	}

	public void SignIn()
	{
		// signInButton.gameObject.SetActive(false);
		
	}

	public void RSVP()
	{
		unRsvpButton.gameObject.SetActive(true);
		rsvpButton.gameObject.SetActive(false);
		_controller.user.eventsGoing.Add(_event);
	}
	
	public void UnRSVP()
	{
		unRsvpButton.gameObject.SetActive(false);
		rsvpButton.gameObject.SetActive(true);
		_controller.user.eventsGoing.Remove(_event);
	}
}
