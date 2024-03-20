using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Grab;

public class Pincette : MonoBehaviour
{
    public enum State // �ɼ��� ���� {�տ� ���� ����, �տ� ������ ���� ����}
    {
        Released,
        Grabbed
    }

    public State state;

    public HandGrabInteractable handInteract;
    public HandGrabInteractor handGrabInteractorR;

    public Transform handTransform; // �ɼ��� ����� �� �տ� ��ġ�� Transform

    MeshRenderer meshRenderer;

    private void Awake()
    {
       meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        /*if (handGrabInteractorR.IsGrabbing)
        {
            if (handGrabInteractorR.CurrentGrabType() == GrabTypeFlags.Palm)
            {
                setRed();
            }
            else if (handGrabInteractorR.CurrentGrabType() == GrabTypeFlags.Pinch)
            {
                setBlack();
            }
        }*/

        // Grabbed ������ ��
        if (state == State.Grabbed)
        {
            // Pinch Grab ������ ��
            if (handGrabInteractorR.CurrentGrabType() == GrabTypeFlags.Pinch)
            {
                setBlack();
            }
            else
            {
                setRed();
            }
        }

        // �տ� ������ ���� ������ ��
        else
        {
            setBlack();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // �տ� ������ ���� ���¿��� Player(Layer 7)�� �浹�ϸ� Grabbed ���·� ��ȯ
        if (state == State.Released && collision.gameObject.layer == 7)
        {
            state = State.Grabbed;
            transform.position = handTransform.position;
        }
    }


    private void setRed()
    {
        meshRenderer.material.color = Color.red;
    }

    private void setBlack()
    {
        meshRenderer.material.color = Color.black;
    }

    private void setGreen()
    {
        meshRenderer.material.color = Color.green;
    }
}
