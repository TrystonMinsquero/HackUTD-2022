using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

[RequireComponent(typeof(NetworkObject), typeof(NetworkTransform))]
public class Player : NetworkBehaviour
{
	public override void OnNetworkSpawn()
	{
		if (!IsOwner)
		{
			Destroy(this);
			return;
		}
		GetComponent<NetworkTransform>().InLocalSpace = true;
	}
}
