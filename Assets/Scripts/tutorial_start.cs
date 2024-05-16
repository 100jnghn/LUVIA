using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_start : MonoBehaviour
{
    public GameObject imageObject;
    public GameObject imageObject_info;

    public float delayTime = 3f; // �̹����� Ȱ��ȭ�� �� ��Ȱ��ȭ�� �������� ��� �ð�

    void Start()
    {
        // �̹����� Ȱ��ȭ�� ��쿡�� ������ �ð� �Ŀ� ��Ȱ��ȭ�ϴ� �ڷ�ƾ ����
        if (imageObject.activeSelf)
        {
            StartCoroutine(DisableImageAfterDelay(delayTime));
        }
    }

    // ���� �ð��� ���� �Ŀ� �̹����� ��Ȱ��ȭ�ϴ� �ڷ�ƾ
    IEnumerator DisableImageAfterDelay(float delay)
    {
        // delay �ð���ŭ ���
        yield return new WaitForSeconds(delay);

        // �̹��� ��Ȱ��ȭ
        imageObject.SetActive(false);
        //StartCoroutine(DisableImageAfterDelay(delayTime));
        imageObject_info.SetActive(true);
    }

}