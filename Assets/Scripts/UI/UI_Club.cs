using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Club : MonoBehaviour
{
	public RectTransform clubTransform;
	public TextMeshProUGUI nameText, presidentText, description;
	public Image presidentImage;
	
	public int startPosition, endPosition;
	public float duration = 0.3f;
	public AnimationCurve lerpCurve;
	private bool busy = false;
	
	public ClubObject attachedClub;
	
	void Start() {
		clubTransform.anchoredPosition = new Vector2(0, startPosition);
	}
	
    void Update()
	{
	    string name="", pres="", desc="";
	    Sprite presImage=null;
	    
	    if (attachedClub != null) {
	    	name = attachedClub.name;
	    	pres = $"President\n<b>{attachedClub.president}";
	    	desc = attachedClub.description;
	    	presImage = attachedClub.presidentIcon;
	    }
	    
	    nameText.text = name;
	    presidentText.text = pres;
	    description.text = desc;
	    presidentImage.sprite = presImage;
    }
    
	public void open() {
		StartCoroutine(lerp(startPosition, endPosition));
	}
	
	public void close() {
		StartCoroutine(lerp(endPosition, startPosition));
	}
	
	private IEnumerator lerp(int a, int b) {
		if (!busy) {
			busy = true;
			float time = 0;
			while (time < duration) {
				float l = Mathf.Lerp(a, b, lerpCurve.Evaluate(time / duration));
				clubTransform.anchoredPosition = new Vector2(0, l);	
				time += Time.deltaTime;
				yield return null;
			}
			
			clubTransform.anchoredPosition = new Vector2(0, b);
			busy = false;
		}
	}
	
	public void Join() {
		if (attachedClub.scene.Length > 0)
			SceneManager.LoadScene(attachedClub.scene);
	}
}
