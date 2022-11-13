using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeClub : MonoBehaviour
{
	[SerializeField]
	private UI_Club uiClub;
	public TMPro.TextMeshProUGUI nameText;
	public Image image;
	public Button button;

	private void OnValidate()
	{
		if (!uiClub) uiClub = FindObjectOfType<UI_Club>();
	}
	
	public void Set(string text, Sprite image, ClubObject clubObject) {
		nameText.text = text;
		this.image.sprite = image;
		button.onClick.AddListener(() => uiClub.open(clubObject));
	}
}
