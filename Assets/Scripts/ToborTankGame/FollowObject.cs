using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
	[SerializeField] private Transform _objToFollow;
	[SerializeField] private float _followSpeed = 10;
	[SerializeField] private bool _rotX = true;
	[SerializeField] private bool _rotY = true;
	[SerializeField] private bool _rotZ = true;
	
	private void LateUpdate()
	{
		var speed = _followSpeed * Time.deltaTime;
		transform.position = Vector3.Lerp(transform.position, _objToFollow.position, speed);
		var orig = transform.rotation.eulerAngles;
		var rot = Quaternion.Lerp(transform.rotation, _objToFollow.rotation, speed).eulerAngles;
		transform.rotation = Quaternion.Euler(new Vector3(_rotX ? rot.x : orig.x, _rotY ? rot.y : orig.y, _rotZ ? rot.z : orig.z));
    }
}
