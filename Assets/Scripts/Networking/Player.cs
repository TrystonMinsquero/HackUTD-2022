using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
	public override void OnNetworkSpawn()
	{
		if (!IsOwner)
		{
			Destroy(this);
		}
	}
	
	private void Update()
    {
	    var movement = (Vector3)InputControls.LeftAxisInput;
	    transform.position += movement * Time.deltaTime;
    }
}
