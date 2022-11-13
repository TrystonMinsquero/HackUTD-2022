using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
	public List<Event> events;
	
	public Event eventPrefab;
	public RectTransform eventContent;
	
    void Start()
    {
        
    }
    
	public void Reset() {
		foreach (Event ev in events) {
			Destroy(ev.gameObject);
		}
		events.Clear();
		
		Event e = Instantiate(eventPrefab, eventContent);
		int n = Random.Range(0, 2);
		if (n == 0)
			e.SetEvent("Flu Vaccinations", "Student Health Center", "Weekdays", "3:00pm - 7:00pm", "With the upcoming flu season, now is the best time to get vaccinated!", "SSB 4.221", true);
		if (n == 1)
			e.SetEvent("Emo Nite", "Strings Attached", "Nov 15", "7:00pm - 10:00pm", "It's not a phase, it's a lifestyle! Come see your favorite Emo songs played by UTD's Strings Attached!", "The Plinth", true);
		events.Add(e);
	}
	
	public void AddEvents(List<EventObject> eventObjects) {
		foreach (EventObject e in eventObjects) {
			Event ev = Instantiate(eventPrefab, eventContent);
			ev.SetEvent(e.name, e.club, e.date, e.time, e.desc, e.location);
			events.Add(ev);
		}
	}
}
