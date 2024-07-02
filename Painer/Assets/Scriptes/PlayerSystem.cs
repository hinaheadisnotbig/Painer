using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    public CameraMove cam;
    public GameObject spawnpoint;
    public GameObject Screeneffect;
    public GameObject Game;

    public int deadcount = 0;
    public int spawnpointvalue = 0;
    public float speed = 4f;
    public bool isjumping = false;
    public bool notmoving = false;
    private bool jumppossible = true;
    private float tempJumpPower = 0f;
    public float jumpPower = 20f;
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
        dir.z = Input.GetAxis("Vertical");   // x�� ���� Ű �Է�
        dir.x = 0;     // z�� ���� Ű �Է�
        }
          if (cam.cameraMode == 1 || cam.cameraMode == 2)
        {
        dir.x = Input.GetAxis("Horizontal");   // x�� ���� Ű �Է�
        dir.z = Input.GetAxis("Vertical");     // z�� ���� Ű �Է�
        }
        if (cam.cameraMode == 3)
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
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isjumping && jumppossible)
        {
            isjumping = true; jumppossible = false;
            characterRigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            StartCoroutine(JumpCooltime(1f));
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

    public void MovePlayer(int mode)
    {
        if(mode == 0)
        {
            transform.position = new Vector3(4.93f, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("event"))
        {
            UnityEngine.Debug.Log("�̺�Ʈ");
            cam.ChangeCameraMode(other.GetComponent<ChangeBlock>().modevaule);
            other.gameObject.SetActive(false);
        }
        if (other.transform.CompareTag("Death"))
        {
           PlayerDead();
        }
    }

    IEnumerator JumpCooltime(float t)
    {
        yield return new WaitForSeconds(t);
        jumppossible = true;
    }

    public bool getjumppossible()
    {
        return jumppossible;
    }
    public void setjumppossible(bool j)
    {
        jumppossible = j;
    }
    public float gettempJumpPower()
    {
        return tempJumpPower;
    }
    public void settempJumpPower(float j)
    {
        tempJumpPower = j;
    }

    public void PlayerDead()
    {
        if (Dead == false)
        {
            UnityEngine.Debug.Log("���");
            Screeneffect.transform.gameObject.SetActive(true);
            Screeneffect.GetComponent<ScreenEffect>().fadeln(1);
            Dead = true;
            gameObject.SetActive(false);
        }
    }



}

