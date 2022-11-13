using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Home : MonoBehaviour
{
	[SerializeField] private UI_Controller _controller;
	[SerializeField] private TextMeshProUGUI _usernameText;
	[SerializeField] private HomeClub _clubPrefab;
	[SerializeField] private RectTransform _clubContent;
	[SerializeField] private List<HomeClub> clubs = new List<HomeClub>();
	[SerializeField] private Friend _friendPrefab;
	[SerializeField] private RectTransform _friendContent;
	[SerializeField] private List<Friend> friends = new List<Friend>();
	
	private void OnValidate()
	{
		if (!_controller) _controller = FindObjectOfType<UI_Controller>();
	}
	
	void OnEnable()
	{
		_usernameText.text = _controller.user.firstName;
		Reset();
		AddClubs();
		AddFriends();
	}
    
	private void Reset()
	{
		foreach (HomeClub ev in clubs) {
			Destroy(ev.gameObject);
		}
		foreach (Friend f in friends) {
			Destroy(f.gameObject);
		}
		friends.Clear();
		clubs.Clear();
	}
	
	private void AddClubs()
	{
		foreach (ClubObject e in _controller.user.userClubs) {
			HomeClub ev = Instantiate(_clubPrefab, _clubContent);
			ev.Set(e.name, e.icon, e);
			clubs.Add(ev);
		}
	}
	
	private void AddFriends()
	{
		foreach (string f in _controller.user.friends)
		{
			Friend friend = Instantiate(_friendPrefab, _friendContent);
			friend.SetText(f);
			friends.Add(friend);
		}
	}
}
