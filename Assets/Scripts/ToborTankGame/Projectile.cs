using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _gravity;
	
	private void Update()
	{
		transform.position += (_speed * Time.deltaTime * transform.forward) + (_gravity * Time.deltaTime * -transform.up);
	
	}
	
	protected void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<ToborTank>()) return;
		
		
		var remoteTank = other.GetComponent<EnemyTank>();
		if (remoteTank)
		{
			Debug.Log("Destroy other tank");
		}
	}
}
