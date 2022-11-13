using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private float _gravity;
	
	public Action<Projectile> destroyMeDaddy = delegate(Projectile projectile) {  };
	
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
