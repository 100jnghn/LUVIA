using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelPressed : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // ����� �±װ� tools�� ��� ������Ʈ�� �����ϴ� ����
        // ���߿� �߰� �������� Ư�� ������ ���쵵�� ����
        GameObject[] toolsObjects = GameObject.FindGameObjectsWithTag("Tools");
        foreach (GameObject tool in toolsObjects)
        {
            Destroy(tool);
        }
    }
}
