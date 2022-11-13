using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private Vector3 hiddenPosition;
    
    private Projectile[] projectiles;

    private Stack<Projectile> unusedProjectiles;

    private void Awake()
    {
        projectiles = GetComponentsInChildren<Projectile>();
        unusedProjectiles = new Stack<Projectile>();
        foreach (var projectile in projectiles)
        {
            projectile.transform.position = hiddenPosition;
            unusedProjectiles.Push(projectile);
        }
    }

    private void ResetProjectile(Projectile projectile)
    {
        projectile.transform.position = hiddenPosition;
        unusedProjectiles.Push(projectile);
    }

    public Projectile GetProjectile()
    {
        if (unusedProjectiles.Count <= 0) return null;
        var projectile = unusedProjectiles.Pop();
        projectile.destroyMeDaddy += ResetProjectile;
        return projectile;
    }
}
