using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data", fileName = "User")]
public class User : ScriptableObject
{
	public string netId;
	public string password;
	public string firstName;
	public string lastName;
	public List<string> friends;
	public List<ClubObject> userClubs;
	public ClubObject ownClub;
}