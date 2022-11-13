using System;
using UnityEngine;

public class ToborTank : Player
{
	[SerializeField] private float _moveSpeed = 2;
	[SerializeField] private float _turnSpeed = 2;
	[SerializeField] private float _fireCooldown = 2;
	[SerializeField] private Projectile _objToFire;
	[SerializeField] private Transform _firePos;
	
	private Rigidbody Rb;
	private float _forwardAmount;
	private float _turnAmount;

	private void Awake()
	{
		Rb = GetComponent<Rigidbody>();
	}
	
	private void Update()
	{
		_forwardAmount = InputControls.LeftAxisInput.y;
		_turnAmount = InputControls.LeftAxisInput.x;
		
		if (InputControls.LeftAction)
		{
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
		Rb.velocity = moveOffset;
	}

	private void Turn(float speed)
	{
		float turnAmountThisFrame = _turnAmount * speed;
		Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
		Rb.MoveRotation(Rb.rotation * turnOffset);
	}
	
	private void Fire()
	{
		var t = Instantiate(_objToFire).transform;
		t.position = _firePos.position;
		t.rotation = _firePos.rotation;
	}
}