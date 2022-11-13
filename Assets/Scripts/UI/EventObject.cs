using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventObject
{
	public string name, club, date, time, desc, location;

	public EventObject(string name, string club, string date, string time, string desc, string location)
	{
		this.name = name;
		this.club = club;
		this.date = date;
		this.time = time;
		this.desc = desc;
		this.location = location;
	}
}
