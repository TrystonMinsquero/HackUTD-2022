using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private float _speed;
	
	private void Update()
	{
		transform.position += transform.forward * _speed * Time.deltaTime;
	}
	
	protected void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<ToborTank>()) return;
		var remoteTank = other.GetComponent<EnemyTank>();
		if (remoteTank)
		{
			Debug.Log("Destroy other tank");
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
