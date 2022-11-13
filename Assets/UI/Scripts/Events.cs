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
	}
	
	public void AddEvents(List<EventObject> eventObjects) {
		foreach (EventObject e in eventObjects) {
			Event ev = Instantiate(eventPrefab, eventContent);
			ev.SetEvent(e.name, e.club, e.date, e.time, e.desc, e.location);
			events.Add(ev);
		}
	}
}
