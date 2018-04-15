using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Setup : NetworkBehaviour {
    [SerializeField]
    Behaviour[] disableComponents;
    Camera sceneCamera;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (!isLocalPlayer)
        {
            foreach(Behaviour b in disableComponents)
            {
                b.enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if(sceneCamera)
                sceneCamera.gameObject.SetActive(false);
        }
	}
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("cancel");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
    }
    void OnDisable()
    {
        if (sceneCamera)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
