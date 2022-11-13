using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Login : MonoBehaviour
{
	[SerializeField] private UI_Controller _controller;
	[SerializeField] private TMP_InputField _netId;
	[SerializeField] private TMP_InputField _password;
	[SerializeField] private TMP_Text _failedPrompt;
	[SerializeField] private List<User> _users;
	
	private void OnValidate()
	{
		if (!_controller) _controller = FindObjectOfType<UI_Controller>();
	}
	
	private void OnEnable()
	{
		_failedPrompt.gameObject.SetActive(false);
	}
	
	public void Login()
	{
		if (string.IsNullOrEmpty(_netId.text) || string.IsNullOrEmpty(_password.text))
		{
			FailedLogin("Please enter a username and password");
			return;
		}
		bool validUserName = false;
		foreach (var user in _users)
		{
			if (_netId.text.Equals(user.netId))
			{
				validUserName = true;
				if (_password.text.Equals(user.password))
				{
					VerifiedLogin(user);
					return;
				}
			}
		}
		FailedLogin("Invalid Username or Password");
	}
	
	public void VerifiedLogin(User user)
	{
		_controller.user = user;
		_controller.ChangeTab(1);
		_controller.CheckClubAdmin();
	}
	
	private void FailedLogin(string message)
	{
		_failedPrompt.gameObject.SetActive(true);
		_failedPrompt.text = message;
	}
}
