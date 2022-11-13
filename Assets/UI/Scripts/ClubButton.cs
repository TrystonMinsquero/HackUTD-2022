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
	public TextMeshProUGUI nameText, memberText;
	
	public void Apply(ClubObject club) {
		this.club = club;
		
		clubImage.sprite = club.icon;
		nameText.text = club.name;
		memberText.text = $"{club.memberCount} members";
		
		gradient.LinearColor1 = club.startColor;
		gradient.LinearColor2 = club.endColor;
	}
}
