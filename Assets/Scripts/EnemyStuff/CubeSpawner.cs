using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CubeSpawner : NetworkBehaviour {

    [SerializeField]
    private GameObject cube;

    [SerializeField]
    private int numberOfCube;

    private Dictionary<string, Cube> cubes = new Dictionary<string, Cube>();

    public override void OnStartServer()
    {
        for(int i = 0; i < numberOfCube; i++)
        {
            GameObject spawnedCube = Instantiate(cube, new Vector3(Random.Range(0, 40),0 , Random.Range(0, 40)), Quaternion.identity);
            NetworkServer.Spawn(spawnedCube);
            cubes.Add(spawnedCube.GetComponent<NetworkIdentity>().netId.ToString(), spawnedCube.GetComponent<Cube>());
        }
    }

    [Command]
    public void CmdKillCube(string cubeId)
    {
        Debug.Log("CubeSpawner - Kill this cube");
        NetworkServer.Destroy(cubes[cubeId].gameObject);
        cubes.Remove(cubeId);
    }
}
