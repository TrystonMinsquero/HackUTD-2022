using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class Player : NetworkBehaviour
{
	[SerializeField] private NetworkTransform _netTransform;
	
	public override void OnNetworkSpawn()
	{
		if (!IsOwner)
		{
			Destroy(this);
			return;
		}
		if (!_netTransform) _netTransform = GetComponent<NetworkTransform>();
		_netTransform.InLocalSpace = true;
	}
	
	private void Update()
    {
	    var movement = (Vector3)InputControls.LeftAxisInput;
	    transform.position += movement * Time.deltaTime;
    }
}
