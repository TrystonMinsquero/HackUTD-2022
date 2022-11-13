using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public enum Sorting {
	Name,
	MemberCount,
	Tag,
	Meter,
}

public class UI_Catalog : MonoBehaviour
{
	[SerializeField] private UI_Club uiClub;
	[SerializeField] private List<ClubObject> clubs;
	[SerializeField] private Sorting sorting = Sorting.Meter;
	[SerializeField] private TMP_InputField field;
	[SerializeField] private ClubButton clubPrefab;
	// [SerializeField] private Image searchImageIcon;
	// [SerializeField] private Sprite brainIcon;
	// [SerializeField] private Sprite searchIcon;
	[SerializeField] private RectTransform content;
	[SerializeField] private List<ClubButton> clubButtons;
	[SerializeField] private string searchText = "";
	
	private void OnValidate()
	{
		if (!uiClub) uiClub = FindObjectOfType<UI_Club>();
	}

	private void OnEnable()
	{		
		Reset();
		AddClubs();
		Sort();
	}
    
	private void Reset()
	{
		foreach (ClubButton club in clubButtons) {
			Destroy(club.gameObject);
		}
		clubButtons.Clear();
	}
	
	private void AddClubs()
	{
		foreach (ClubObject club in clubs) {
			ClubButton button = Instantiate(clubPrefab, content);
			button.Apply(club);
	    	
			clubButtons.Add(button);
	    	
			string scene = club.scene;
			button.button.onClick.AddListener(() => {
				LoadClubDetails(button.club);
			});
		}
	}

	public void LoadClubDetails(ClubObject club) {
		uiClub.open(club);
	}
    
	public void Type() {
		sorting = Sorting.Name;
		searchText = field.text.ToLower();
		
		foreach (ClubButton button in clubButtons) {
			bool contains = button.searchableText.Contains(searchText);
			button.meter.gameObject.SetActive(contains);
		}
		
		Sort();
	}
	
	public void SetSort(Sorting sorting) {
		this.sorting = sorting;
		// searchImageIcon.sprite = sorting == Sorting.Meter ? brainIcon : searchIcon;
		Sort();
	}
	
	public void Sort() {
		switch(sorting) {
		case Sorting.Name:
			clubButtons.Sort(CompareName);
			break;
		case Sorting.Tag:
			clubButtons.Sort(CompareTag);
			break;
		case Sorting.MemberCount:
			clubButtons.Sort(CompareMemberCount);
			break;
		case Sorting.Meter:
			clubButtons.Sort(CompareMeter);
			break;
		}
		
		int i = 0;
		foreach (ClubButton button in clubButtons) {
			button.transform.SetSiblingIndex(i++);
			button.meter.gameObject.SetActive(sorting == Sorting.Meter);
		}
	}
	
	public int CompareName(ClubButton a, ClubButton b) {
		return string.Compare(a.club.name, b.club.name);
	}
	
	public int CompareMemberCount(ClubButton a, ClubButton b) {
		return a.club.memberCount.CompareTo(b.club.memberCount);
	}
	
	public int CompareTag(ClubButton a, ClubButton b) {
		return a.club.categories[0].CompareTo(b.club.categories[0]);
	}
	
	public int CompareMeter(ClubButton a, ClubButton b) {
		return b.meter.Value.CompareTo(a.meter.Value);
	}
	
	public void SearchAI() {
		#if UNITY_EDITOR
		var descs = new List<string>();
		
		foreach (ClubButton btn in clubButtons) {
			descs.Add(btn.club.description);
			btn.meter.gameObject.SetActive(true);
		}
		
		var results = AI.Run(searchText, descs);
		var min = results.Min();
		var max = results.Max();
		for (int i = 0; i < results.Length; i++) {
			var n = results[i];
			results[i] = Mathf.Pow(Mathf.InverseLerp(min, max, n), 2) * Mathf.Lerp(1, max, 0.5f);
		}
		
		
		for (int i = 0; i < results.Length; i++) {
			clubButtons[i].gameObject.SetActive(true);
			clubButtons[i].meter.SetValue(results[i]);
		}
		
		sorting = Sorting.Meter;
		Sort();
		#endif
	}
}
