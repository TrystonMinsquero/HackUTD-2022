using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
	[SerializeField] private UI_Controller _controller;
	[SerializeField] private Event eventPrefab;
	[SerializeField] private RectTransform eventContent;
	[SerializeField] private List<Event> events;
    
	private void OnValidate()
	{
		if (!_controller) _controller = FindObjectOfType<UI_Controller>();
	}
	
	private void OnEnable()
	{
		Reset();
		foreach (ClubObject club in _controller.user.userClubs) {
			AddEvents(club.events);
		}
	}
	
	private void Reset() {
		foreach (Event ev in events) {
			Destroy(ev.gameObject);
		}
		events.Clear();
		
		// Event e = Instantiate(eventPrefab, eventContent);
		// // int n = Random.Range(0, 2);
		// // if (n == 0)
		// // 	e.SetEvent("Flu Vaccinations", "Student Health Center", "Weekdays", "3:00pm - 7:00pm", "With the upcoming flu season, now is the best time to get vaccinated!", "SSB 4.221", true);
		// // if (n == 1)
		// // 	e.SetEvent("Emo Nite", "Strings Attached", "Nov 15", "7:00pm - 10:00pm", "It's not a phase, it's a lifestyle! Come see your favorite Emo songs played by UTD's Strings Attached!", "The Plinth", true);
		// events.Add(e);
	}
	
	private void AddEvents(List<EventObject> eventObjects) {
		foreach (EventObject e in eventObjects) {
			Event ev = Instantiate(eventPrefab, eventContent);
			ev.SetEvent(e);
			events.Add(ev);
		}
	}
}
