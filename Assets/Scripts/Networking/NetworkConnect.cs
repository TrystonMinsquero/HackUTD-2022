using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;

public class NetworkConnect : MonoBehaviour
{	
	[SerializeField] private bool _debug;
	[SerializeField] private string JoinCodeKey = "j";
	
	private Lobby _connectedLobby;
	private QueryResponse _lobbies;
	private UnityTransport _transport;
	private const int MaxPlayers = 100;
	private string _playerId;
	
	private void Awake()
	{
		_transport = FindObjectOfType<UnityTransport>();
	}
	
	private void Start()
	{
		CreateOrJoinLobby();
	}
	
	private async void CreateOrJoinLobby()
	{
		if (_debug) Debug.Log("Authenticate");
		await Authenticate();
		
		if (_debug) Debug.Log("SignInAnonymouslyAsync");
		await AuthenticationService.Instance.SignInAnonymouslyAsync();
		
		_connectedLobby = await QuickJoinLobby() ?? await CreateLobby();
	}
	
	private async Task Authenticate()
	{
		var options = new InitializationOptions();
		
		await UnityServices.InitializeAsync(options);
		_playerId = AuthenticationService.Instance.PlayerId;
	}
	
	private async Task<Lobby> QuickJoinLobby()
	{
		try {
			if (_debug) Debug.Log("QuickJoinLobbyAsync");
			var lobby = await Lobbies.Instance.QuickJoinLobbyAsync();
		
			if (_debug) Debug.Log("JoinAllocationAsync");
			var a = await RelayService.Instance.JoinAllocationAsync(lobby.Data[JoinCodeKey].Value);
		
			SetTransformAsClient(a);
		
			if (_debug) Debug.Log("StartClient");
			NetworkManager.Singleton.StartClient();
			return lobby;
		}
		catch {
			return null;
		}
	}
	
	private async Task<Lobby> CreateLobby()
	{
		try {
			if (_debug) Debug.Log("CreateAllocationAsync");
			var a = await RelayService.Instance.CreateAllocationAsync(MaxPlayers);
			
			if (_debug) Debug.Log("GetJoinCodeAsync");
			var joinCode = await RelayService.Instance.GetJoinCodeAsync(a.AllocationId);
			
			var options = new CreateLobbyOptions {
				Data = new Dictionary<string, DataObject> { { JoinCodeKey, new DataObject(DataObject.VisibilityOptions.Public, joinCode) } }
			};
			
			if (_debug) Debug.Log("CreateLobbyAsync");
			var lobby = await Lobbies.Instance.CreateLobbyAsync("Lobby Name", MaxPlayers, options);
			
			_transport.SetHostRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData);
			
			if (_debug) Debug.Log("StartHost");
			NetworkManager.Singleton.StartHost();
			return lobby;
		}
		catch {
			return null;
		}
	}
	
	private void SetTransformAsClient(JoinAllocation a)
	{
		_transport.SetClientRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData, a.HostConnectionData);
	}
	
	private static IEnumerator HeartbeatLobbyRoutine(string lobbyId, float waitSeconds)
	{
		var delay = new WaitForSecondsRealtime(waitSeconds);
		while (true)
		{
			Lobbies.Instance.SendHeartbeatPingAsync(lobbyId);
			yield return delay;
		}
	}
	
	private void OnDestroy()
	{
		try {
			if (_connectedLobby != null)
			{
				if (_debug) Debug.Log("Disconnect From Lobby");
				if (_connectedLobby.HostId == _playerId) Lobbies.Instance.DeleteLobbyAsync(_connectedLobby.Id);
				else Lobbies.Instance.RemovePlayerAsync(_connectedLobby.Id, _playerId);
			}
		}
		catch {
			
		}
	}
}
