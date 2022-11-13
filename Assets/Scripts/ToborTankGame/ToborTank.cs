using System;
using Unity.Netcode;
using UnityEngine;

public class ToborTank : Player
{
	[SerializeField] private float _moveSpeed = 2;
	[SerializeField] private float _turnSpeed = 2;
	[SerializeField] private float _fireCooldown = 2;
	[SerializeField] GameObject _projectilePrefab;
	[SerializeField] private Transform _firePos;
	
	NetworkVariable<Vector3> pos = new NetworkVariable<Vector3>(Vector3.zero,NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
	NetworkVariable<Quaternion> rot = new NetworkVariable<Quaternion>(Quaternion.identity,NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
	
	private Rigidbody _rb;
	private float _forwardAmount;
	private float _turnAmount;
	private float _fireTime;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}
	
	private void Update()
	{
		if (!IsOwner) {
			Debug.Log(pos.Value);
			transform.position = Vector3.Lerp(transform.position, pos.Value, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, rot.Value, Time.deltaTime * 5);
			
			return;
		}
		
		
		_forwardAmount = InputControls.LeftAxisInput.y;
		_turnAmount = InputControls.LeftAxisInput.x;
		
		if (InputControls.LeftAction)
		{
			if (Time.time - _fireTime < _fireCooldown) return;
			_fireTime = Time.time;
			Fire();
		}
		
		pos.Value = transform.position;
		rot.Value = transform.rotation;
	}
	
	private void FixedUpdate()
	{
		if (!IsOwner) return;
		
		Turn(_turnSpeed);
		Move(_moveSpeed);
	}
	
	protected override void OnNotOwner()
	{
		gameObject.AddComponent<EnemyTank>();
	}

	private void Move(float speed)
	{
		float moveAmountThisFrame = _forwardAmount * speed;
		Vector3 moveOffset = transform.forward * moveAmountThisFrame;
		_rb.velocity = moveOffset;
	}

	private void Turn(float speed)
	{
		float turnAmountThisFrame = _turnAmount * speed;
		Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
		_rb.MoveRotation(_rb.rotation * turnOffset);
	}

	private void Fire()
	{
		//var projectile = NetworkObjectPool.Singleton.GetNetworkObject(_projectilePrefab, _firePos.position, _firePos.rotation );
		//projectile.GetComponent<Projectile>().destroyMeDaddy += CleanProjectile;
		ShootClientRpc(_firePos.position, _firePos.rotation);
	}

	private void CleanProjectile(NetworkObject projectile)
	{
		NetworkObjectPool.Singleton.ReturnNetworkObject(projectile, _projectilePrefab);
	}

	[ServerRpc(RequireOwnership = false)]
	private void FireServerRPC(ServerRpcParams serverRpcParams = default)
	{
		var clientId = serverRpcParams.Receive.SenderClientId;
		if (NetworkManager.ConnectedClients.ContainsKey(clientId))
		{
			var client = NetworkManager.ConnectedClients[clientId];
			var projectile = Instantiate(_projectilePrefab);
			projectile.GetComponent<NetworkObject>().SpawnWithOwnership(clientId);
			client.PlayerObject.GetComponent<ToborTank>().FireProjectile(projectile.GetComponent<Projectile>());
		}
	}

	private void FireProjectile(Projectile projectile)
	{
		var t = projectile.transform;
		t.position = _firePos.position;
		t.rotation = _firePos.rotation;
	}
	
	[ClientRpc]
	private void ShootClientRpc(Vector3 pos, Quaternion rot) {
		var s = Instantiate(_projectilePrefab, pos, rot);
		
	}
}