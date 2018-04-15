using System;
using UnityEngine;
using UnityEngine.Networking;

public class Gun : Weapon
{
    [SerializeField]
    private LayerMask mask;

    
    public override void Shoot()
    {
        Ray _ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit _hit;
        if (Physics.Raycast(_ray, out _hit, range, mask))
        {
            // Deal damage to the cube we just hit
            _hit.collider.gameObject.GetComponent<Cube>().TakeDamage(this.damage);
        }
    }
}
