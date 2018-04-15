using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public abstract class Weapon : MonoBehaviour {

    //Default weapon
    public string weaponName = "Gun";
    public int damage = 10;
    public float range = 100f;
    public abstract void Shoot();
}
