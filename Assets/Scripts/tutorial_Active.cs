using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_Active : MonoBehaviour
{
    public GameObject imageObject; // Ȱ��ȭ�� �̹��� GameObject

    void Start()
    {
        // 4�� �Ŀ� �̹����� Ȱ��ȭ�ϴ� �ڷ�ƾ ����
        Invoke("ActivateImage", 4f);
    }

    // �̹����� Ȱ��ȭ�ϴ� �޼���
    void ActivateImage()
    {
        if (!imageObject.activeSelf)
        {
            imageObject.SetActive(true);
        }
    }

}
