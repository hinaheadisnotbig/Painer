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
        dir.z = Input.GetAxis("Vertical");   // x축 방향 키 입력
        dir.x = 0;     // z축 방향 키 입력
        }
          if (cam.cameraMode == 1)
        {
        dir.x = Input.GetAxis("Horizontal");   // x축 방향 키 입력
        dir.z = Input.GetAxis("Vertical");     // z축 방향 키 입력
        }
        if (dir != Vector3.zero)   // 키입력이 존재하는 경우
        {
            transform.forward = dir;	// 키 입력 시, 입력된 방향으로 캐릭터의 방향을 바꿈
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
        UnityEngine.Debug.Log("닿음");
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

