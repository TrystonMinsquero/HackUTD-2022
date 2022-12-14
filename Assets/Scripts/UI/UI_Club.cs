using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class UI_Club : MonoBehaviour
{
	[SerializeField] private UI_Controller _controller;
	public RectTransform clubTransform;
	public TMP_Text abbrevText, nameText, presidentText, tagline, description, memberCount, members;
	public Image logoImage;
	public Image presidentImage;
	
	public int startPosition, endPosition;
	public float duration = 0.3f;
	public AnimationCurve lerpCurve;
	[SerializeField] private GameObject _joinClubButton;
	[SerializeField] private GameObject _leaveClubButton;
	
	public ClubObject attachedClub;
	
	private bool InClub => _controller.user.userClubs.Contains(attachedClub);
	
	private bool busy = false;
	
	private void OnValidate()
	{
		if (!_controller) _controller = FindObjectOfType<UI_Controller>();
	}
	
	private void Start()
	{
		clubTransform.anchoredPosition = new Vector2(0, startPosition);
	}
	
	public void open(ClubObject club) {
		attachedClub = club;
	    
		if (abbrevText) abbrevText.text = attachedClub.abbreviation;
		if (nameText) nameText.text = attachedClub.name;
		if (presidentText) presidentText.text = $"<b>Description";
		if (tagline) tagline.text = attachedClub.shortKeyWords;
		if (description) description.text = attachedClub.description;
		if (description) description.text = attachedClub.description;
		if (logoImage) logoImage.sprite = attachedClub.icon;
		if (presidentImage) presidentImage.sprite = attachedClub.presidentIcon;
		if (memberCount) 
		{
			int mut = (from m in attachedClub.members.GetNames() where _controller.user.friends.Contains(m) select m).ToList().Count;
			memberCount.text = $"{attachedClub.members.GetNames().Length} Students\n{mut} Mutual Friends";
		}
		if (members) members.text = attachedClub.members.namesText;
		
		CheckJoined();
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
	
	public void JoinLobby() {
		if (attachedClub.scene.Length > 0)
			SceneManager.LoadScene(attachedClub.scene);
	}
	
	public void JoinClub()
	{
		if (!InClub)
		{
			_controller.user.userClubs.Add(attachedClub);
		}
		CheckJoined();
	}
	
	public void LeaveClub()
	{
		if (InClub)
		{
			_controller.user.userClubs.Remove(attachedClub);
		}
		CheckJoined();
	}
		
	private void CheckJoined()
	{
		bool inClub = InClub;
		_joinClubButton.SetActive(!inClub);
		_leaveClubButton.SetActive(inClub);
	}
}
