using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    [SerializeField]
    float speed = 3f;

    [SerializeField]
    float rotationSpeed = 2f;

    [SerializeField]
    Camera cam;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate () {
        Move();
	}

    void Move()
    {
        //GetInput
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        float _yRot = Input.GetAxisRaw("Mouse X");
        float _xRot = Input.GetAxisRaw("Mouse Y");

        //Compute
        Vector3 _movHorizontal = transform.right * _xMov;
        Vector3 _movVertical = transform.forward * _zMov;

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * rotationSpeed;
        Vector3 _camRotation = new Vector3(_xRot, 0f, 0f) * rotationSpeed;
        //Move
        rb.MovePosition(rb.position + _velocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(_rotation));
        if(cam)
            cam.transform.Rotate(-_camRotation);
    }
}
