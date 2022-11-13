using System.Collections;
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
	
	[SerializeField] List<ClubObject> clubs = new List<ClubObject>();
	[SerializeField] RectTransform content;
	[SerializeField] ClubButton clubPrefab;
	[SerializeField] Sorting sorting = Sorting.Name;
	[SerializeField] TMP_InputField field;
	
	UI_Club uiClub;
	
	public string searchText = "";
	
	List<ClubButton> clubButtons = new List<ClubButton>();
	
	public void updateSearch() {
		
	}
	
    // Start is called before the first frame update
    void Start()
	{
		uiClub = GetComponent<UI_Club>();
		
		foreach (Transform obj in content) {
			Destroy(obj.gameObject);
		}
		
	    foreach (ClubObject club in clubs) {
	    	ClubButton button = Instantiate(clubPrefab, content);
	    	button.Apply(club);
	    	
	    	clubButtons.Add(button);
	    	
	    	string scene = club.scene;
	    	button.button.onClick.AddListener(() => {
	    		LoadContent(button.club);
	    	});
	    }
	    
		Sort();
    }

	public void LoadContent(ClubObject club) {
		uiClub.attachedClub = club;
		uiClub.open();
	}

    // Update is called once per frame
    void Update()
    {
        
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
