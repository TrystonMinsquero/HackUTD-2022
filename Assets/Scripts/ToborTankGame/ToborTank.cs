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
		_forwardAmount = InputControls.LeftAxisInput.y;
		_turnAmount = InputControls.LeftAxisInput.x;
		
		if (InputControls.LeftAction)
		{
			if (Time.time - _fireTime < _fireCooldown) return;
			_fireTime = Time.time;
			Fire();
		}
	}
	
	private void FixedUpdate()
	{
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
		var projectile = NetworkObjectPool.Singleton.GetNetworkObject(_projectilePrefab, _firePos.position, _firePos.rotation );
		projectile.GetComponent<Projectile>().destroyMeDaddy += CleanProjectile;
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
}