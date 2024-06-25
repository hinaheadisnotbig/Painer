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
    public bool notmoving = false;
    public bool jumppossible = true;
    public float tempJumpPower = 0f;
    public float jumpPower = 20;
    public bool Dead = false;

    private Rigidbody characterRigidbody;
    Vector3 dir = Vector3.zero;

    void Awake()
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
          if (cam.cameraMode == 1 || cam.cameraMode == 2)
        {
        dir.x = Input.GetAxis("Horizontal");   // x축 방향 키 입력
        dir.z = Input.GetAxis("Vertical");     // z축 방향 키 입력
        }
        if (cam.cameraMode == 3)
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
        if (Input.GetKey(KeyCode.Space) && !isjumping && jumppossible)
        {
            isjumping = true; jumppossible = false;
            characterRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            StartCoroutine(JumpCooltime(1.5f));
        }
        inputAndDir();
    }
    void FixedUpdate()
    {
        if (notmoving == false)
        {
            if (cam.cameraMode == 3) characterRigidbody.MovePosition(transform.position + -1 * dir * speed * Time.deltaTime);
            else characterRigidbody.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }
    }
    private void OnCollisionStay (Collision collision)
    {
        if(collision.transform.tag == "Ground" && isjumping) isjumping = false;
    }
    private void OnCollisionExit(Collision collision)
    {
        isjumping = true;
    }



    public void MovePlayer(int mode)
    {
        if(mode == 0)
        {
            transform.position = new Vector3(4.93f, transform.position.y, transform.position.z);
        }
        //if (mode == 1)
       // {
       //     transform.position = new Vector3(2.85f, transform.position.y, transform.position.z);
       // }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("jumpblock"))
        {
            jumpPower = tempJumpPower;
            UnityEngine.Debug.Log(tempJumpPower);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("jumpblock"))
        {
            isjumping = false;
            tempJumpPower = jumpPower;
            jumpPower = other.gameObject.GetComponent<JumpBlock>().Jumpvaule;
            UnityEngine.Debug.Log("밞음");
        }
        if (other.transform.CompareTag("event"))
        {
            UnityEngine.Debug.Log("이벤트");
            cam.ChangeCameraMode(other.GetComponent<ChangeBlock>().modevaule);
            other.gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("Death"))
        {
            Dead = true;
        }
    }

    IEnumerator JumpCooltime(float t)
    {
        yield return new WaitForSeconds(t);
        jumppossible = true;
    }



   

}

