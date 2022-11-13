using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
	public List<HomeClub> clubs;
	
	public HomeClub clubPrefab;
	public RectTransform clubContent;
	
	void Start()
	{
        
	}
    
	public void Reset() {
		foreach (HomeClub ev in clubs) {
			Destroy(ev.gameObject);
		}
		clubs.Clear();
	}
	
	public void AddClubs(List<ClubObject> c) {
		foreach (ClubObject e in c) {
			HomeClub ev = Instantiate(clubPrefab, clubContent);
			ev.Set(e.name, e.icon);
			clubs.Add(ev);
		}
	}
}
