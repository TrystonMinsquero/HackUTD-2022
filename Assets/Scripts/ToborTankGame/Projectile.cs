﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _gravity;
	
	public Action<NetworkObject> destroyMeDaddy = delegate(NetworkObject obj) {  };
	
	private void Update()
	{
		transform.position += (_speed * Time.deltaTime * transform.forward) + (_gravity * Time.deltaTime * -transform.up);
		if(transform.position.y < -2) destroyMeDaddy.Invoke(GetComponent<NetworkObject>());
	}
	
	protected void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<ToborTank>()) return;
		
		
		var remoteTank = other.GetComponent<EnemyTank>();
		if (remoteTank)
		{
			Debug.Log("Destroy other tank");
		}
		destroyMeDaddy.Invoke(GetComponent<NetworkObject>());
	}
}
