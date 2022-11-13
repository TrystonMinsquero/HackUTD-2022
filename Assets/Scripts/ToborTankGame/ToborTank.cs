using System;
using UnityEngine;

public class ToborTank : Player
{
    [SerializeField] private float speed;
    
    private void Move()
    {
        Vector3 v = new Vector3(InputControls.RightAxisInput.x, 0, InputControls.LeftAxisInput.y);
        transform.Translate(speed * Time.deltaTime * v);
    }

    private void Shoot()
    {
        
    }

    private void Update()
    {
        Move();
    }
}