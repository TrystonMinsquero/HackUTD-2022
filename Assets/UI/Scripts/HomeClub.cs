using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeClub : MonoBehaviour
{
	public TMPro.TextMeshProUGUI nameText;
	public Image image;
	
	public void Set(string text, Sprite image) {
		nameText.text = text;
		this.image.sprite = image;
	}
}
