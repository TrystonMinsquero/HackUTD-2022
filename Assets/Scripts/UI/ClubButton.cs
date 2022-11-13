using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JoshH.UI;

public class ClubButton : MonoBehaviour
{
	public ClubObject club;
	public Image clubImage;
	public UIGradient gradient;
	public TMP_Text abbrevText, nameText, taglineText, schoolText, memberText;
	public Button button;
	
	public string searchableText = "";
	
	public void Apply(ClubObject club) {
		this.club = club;
		
		clubImage.sprite = club.icon;
		gradient.LinearColor1 = club.startColor;
		gradient.LinearColor2 = club.endColor;
		
		if (abbrevText) abbrevText.text = club.abbreviation;
		if (nameText) nameText.text = club.name;
		if (taglineText) taglineText.text = club.shortKeyWords;
		if (schoolText) schoolText.text = club.categories;
		if (memberText) memberText.text = $"{club.members.GetNames().Length} members";
		
		this.searchableText = club.name.ToLower() + " " + club.description.ToLower();
	}
}
