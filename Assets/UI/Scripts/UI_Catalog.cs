using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Catalog : MonoBehaviour
{
	
	[SerializeField] List<ClubObject> clubs = new List<ClubObject>();
	[SerializeField] 
	
	public string searchText = "", sceneName = "scene";
	
	
	public void updateSearch() {
		
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void filterButton() {
		SceneManager.LoadScene(sceneName);
	}
}
