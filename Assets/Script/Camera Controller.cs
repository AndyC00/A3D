using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 10f;       // �����������ٶ�
    public float rotationSpeed = 100f;  // �����ת�ٶ�

    private Vector3 offset;
    private Transform playerTransform;

    void Start()
    {
        // ���� "Player" ���󲢼����ʼƫ��
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        // ���������λ�ã�ʹ����� "Player"
        transform.position = playerTransform.position + offset;

        // �����������Ұ
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += scroll * zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 37, 70);

        // �����������ת
        if (Input.GetMouseButton(1)) // �Ҽ�����ʱ��ת�����
        {
            // ��ȡ����ˮƽ�ʹ�ֱ����
            float rotateHorizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotateVertical = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime; // ��ת y �᷽��

            // ˮƽ��ת��Χ������� Y �ᣩ
            offset = Quaternion.AngleAxis(rotateHorizontal, Vector3.up) * offset;

            // ��ֱ��ת��Χ��������ı��� X �ᣩ
            offset = Quaternion.AngleAxis(rotateVertical, transform.right) * offset;

            // ȷ�������������� "Player" ����
            transform.LookAt(playerTransform.position);
        }
    }
}
