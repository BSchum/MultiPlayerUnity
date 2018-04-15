using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Cube : NetworkBehaviour {

    [SerializeField]
    int maxHealth = 100;

    [SyncVar]
    int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Debug.Log(currentHealth);
        if(currentHealth <= 0)
        {
            Debug.Log("Cube : Asking the server to kill me");
            GameObject.Find("_CubeSpawner").GetComponent<CubeSpawner>().CmdKillCube(this.GetComponent<NetworkIdentity>().netId.ToString());
        }
    }

    public void TakeDamage(int amount)
    {
        //called by the weapon 
        Debug.Log("I took damage");
        currentHealth -= amount;
    }



}
