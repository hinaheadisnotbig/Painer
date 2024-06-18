using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public CameraMove cam;
    public float speed = 5f;
    public bool isjumping = false;
    private Rigidbody characterRigidbody;
    public float jumpPower = 7;
    Vector3 dir = Vector3.zero;

    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }
    void inputAndDir()
    {
        if (cam.cameraMode == 0)
        {
        dir.z = Input.GetAxis("Vertical");   // x�� ���� Ű �Է�
        dir.x = 0;     // z�� ���� Ű �Է�
        }
          if (cam.cameraMode == 1)
        {
        dir.x = Input.GetAxis("Horizontal");   // x�� ���� Ű �Է�
        dir.z = Input.GetAxis("Vertical");     // z�� ���� Ű �Է�
        }
        if (dir != Vector3.zero)   // Ű�Է��� �����ϴ� ���
        {
            transform.forward = dir;	// Ű �Է� ��, �Էµ� �������� ĳ������ ������ �ٲ�
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isjumping)
        {
            isjumping = true;
            characterRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        inputAndDir();
    }
    void FixedUpdate()
    {
        characterRigidbody.MovePosition(characterRigidbody.position + dir * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("����");
        if(collision.transform.tag == "Ground")
        {
            isjumping = false;
            UnityEngine.Debug.Log("1");
        }
    }

    public void MovePlayer(int mode)
    {
        if(mode == 0)
        {
            transform.position = new Vector3(4.93f, transform.position.y, transform.position.z);
        }
        if (mode == 1)
        {
            transform.position = new Vector3(2.85f, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("mode1"))
        {
            cam.ChangeCameraMode(0);
            Destroy(other);
        }
        if (other.transform.CompareTag("mode2"))
        {
            cam.ChangeCameraMode(1);
            Destroy(other);
        }
    }

}

