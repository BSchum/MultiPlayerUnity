using System;
using UnityEngine;
using UnityEngine.Networking;
public class Attack : NetworkBehaviour {
    public Weapon weapon;
    // Use this for initialization
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot();
        }
	}

}
