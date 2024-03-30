using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���� ��� ����âUI �����ϴ� ��ũ��Ʈ
public class OrganDescription : MonoBehaviour
{
    public Canvas description;

    public bool isActive; // �� ������ ���� description SetActive() ����

    void Start()
    {
        description.gameObject.SetActive(false);
        isActive = false;
    }

    void Update()
    {
        description.gameObject.SetActive(isActive);
    }

    public void setActiveUI()
    {
        isActive = !isActive;
    }
}
