using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category {ECS, JSOM, ATEC, MUSIC}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ClubObject", order = 1)]
public class ClubObject : ScriptableObject
{
	public string name, president, description;
	public List<Category> categories;
	public Sprite icon, presidentIcon;
	public int memberCount;
	public Color startColor, endColor;
	
	public string scene;
}
