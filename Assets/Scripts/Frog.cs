using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    // �������� � ���������� ��Ÿ��
    public enum FrogState
    {
        Idle,
        Grabbed,
        Anesthesia
    };

    // �������� ���¸� �����ϴ� ����
    public FrogState state;

    private Animator animator;

    void Start()
    {
        state = FrogState.Idle;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        checkState(); // ���� üũ
    }

    void checkState()
    {
        if (state == FrogState.Idle)
        {
            // Idle Action �Լ� �ۼ�
        }
        else if (state == FrogState.Grabbed)
        {
            frogGrabbed();
        }
        else if (state == FrogState.Anesthesia)
        {
            // ������� �� Action �Լ� �ۼ�
        }
    }

    public void frogGrabbed()
    {
        
    }
}
