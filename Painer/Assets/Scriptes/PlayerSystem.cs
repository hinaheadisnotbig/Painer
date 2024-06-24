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
    private bool jumppossible = true;
    private float tempJumpPower = 0f;
    private Rigidbody characterRigidbody;
    public float jumpPower = 20;
    Vector3 dir = Vector3.zero;

    void Awake()
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
        if (Input.GetKey(KeyCode.Space) && !isjumping && jumppossible)
        {
            isjumping = true; jumppossible = false;
            characterRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            StartCoroutine(JumpCooltime(2.0f));
        }
        inputAndDir();
    }
    void FixedUpdate()
    {
       if (!notmoving) characterRigidbody.MovePosition(transform.position + dir * speed * Time.deltaTime);
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
        if (mode == 1)
        {
            transform.position = new Vector3(2.85f, transform.position.y, transform.position.z);
        }
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
            UnityEngine.Debug.Log("����");
        }
        if (other.transform.CompareTag("event"))
        {
            UnityEngine.Debug.Log("�̺�Ʈ");
            cam.ChangeCameraMode(other.GetComponent<ChangeBlock>().modevaule);
            Destroy(other);
        }
    }

    IEnumerator JumpCooltime(float t)
    {
        yield return new WaitForSeconds(t);
        jumppossible = true;
    }

  

   

}

