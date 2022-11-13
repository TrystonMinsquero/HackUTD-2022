using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Catalog : MonoBehaviour
{
	
	[SerializeField] List<ClubObject> clubs = new List<ClubObject>();
	[SerializeField] RectTransform content;
	[SerializeField] ClubButton clubPrefab;
	
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
    }

	public void LoadContent(ClubObject club) {
		uiClub.attachedClub = club;
		uiClub.open();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void filterButton() {
		
	}
}
