using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public enum UtdSchool
{
	AHT,
	BBS,
	EPPS,
	ECS,
	IS,
	JSOM,
	NSM
}

public enum ClubCategories
{
	Social,
	Political,
	SpecialInterests,
	Academic,
	Service,
	Religious,
	ArtMusic,
	Culture,
	FratLife,
	Greek,
	Honors,
	Education,
	Recreation,
	Sports,
}
*/

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ClubObject", order = 1)]
public class ClubObject : ScriptableObject
{
	public string abbreviation;
	public string name;
	public string shortKeyWords;
	[TextArea(1, 5)] public string description;
	public string categories;
	public int memberCount;
	public Sprite icon;
	public string president;
	public Sprite presidentIcon;
	public Color startColor;
	public Color endColor;
	
	public string scene;
	
	public List<EventObject> events;
	public Names members;

	public string[] GetFriends(User user)
	{
		return members.GetNames();
	}
#if UNITY_EDITOR
	// [SerializeField] private int numberOfNames
	[Button]
	private void GenerateRandomNames(int num)
	{
		members.namesText = RandomNames.GenerateRandomNamesString(num);
	}
#endif
}
