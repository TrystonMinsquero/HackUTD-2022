﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum Sorting {
	Name,
	MemberCount,
	Tag,
}

public class UI_Catalog : MonoBehaviour
{
	[SerializeField] private UI_Club uiClub;
	[SerializeField] private List<ClubObject> clubs;
	[SerializeField] private Sorting sorting = Sorting.Name;
	[SerializeField] private TMP_InputField field;
	[SerializeField] private ClubButton clubPrefab;
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
		uiClub.attachedClub = club;
		uiClub.open();
	}
    
	public void Type() {
		searchText = field.text.ToLower();
		
		foreach (ClubButton button in clubButtons) {
			bool contains = button.searchableText.Contains(searchText);
			button.gameObject.SetActive(contains);
		}
	}
	
	public void SetSort(Sorting sorting) {
		this.sorting = sorting;
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
		}
		
		int i = 0;
		foreach (ClubButton button in clubButtons) {
			button.transform.SetSiblingIndex(i++);
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
}