using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

[RequireComponent(typeof(NetworkObject))]
public class Player : NetworkBehaviour
{
	public override void OnNetworkSpawn()
	{
		if (!IsOwner)
		{
			Destroy(this);
			OnNotOwner();
			return;
		}
		var t = GetComponent<NetworkTransform>();
		if (t) t.InLocalSpace = true;
		var r = GetComponent<NetworkRigidbody>();
		if (r) t.InLocalSpace = true;
	}
	
	protected virtual void OnNotOwner() {}
}
