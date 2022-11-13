using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
	private void OnNetworkSpawn()
	{
		if (!IsOwner)
		{
			Debug.Log("Is not owner", gameObject);
			Destroy(this);
		}
	}
	
	private void Update()
    {
	    var movement = (Vector3)InputControls.LeftAxisInput;
	    transform.position += movement * Time.deltaTime;
    }
}
