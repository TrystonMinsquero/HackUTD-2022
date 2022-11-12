using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobAndTurnTest : MonoBehaviour
{
	private Vector3 _pos;
	
	private void Start()
	{
		_pos = transform.position;
	}
	
	private void Update()
    {
	    transform.position = _pos + Vector3.up * Mathf.Sin(Time.deltaTime);
    }
}
