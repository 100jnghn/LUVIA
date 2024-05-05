using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Grab;

public class Pincette : MonoBehaviour
{
/*    public enum State // �ɼ��� ���� {�տ� ���� ����, �տ� ������ ���� ����}
    {
        Released,
        Grabbed
    }*/

    //public State state;

    public HandGrabInteractable handInteract;
    public HandGrabInteractor handGrabInteractorL;

    public Transform handTransform; // �ɼ��� ����� �� �տ� ��ġ�� Transform

    public GameObject pincette;
    public GameObject GrabbedPincette;

    private float grabPincetteTime;

    //MeshRenderer meshRenderer;

    /*    private void Awake()
        {
           meshRenderer = GetComponent<MeshRenderer>();
        }*/

    private void Update()
    {
        if (handGrabInteractorL.IsGrabbing)
        {
            if (handGrabInteractorL.CurrentGrabType() == GrabTypeFlags.Pinch)
            {
                grabPincetteTime += Time.deltaTime;

                if (grabPincetteTime > 3.0f)
                {
                    GrabbedPincette.SetActive(true);
                    pincette.SetActive(false);
                }
                else
                {
                    GrabbedPincette.SetActive(false);
                }
            }

        }
        else
        {
            grabPincetteTime = 0.0f;
        }








        if (handGrabInteractorL.CurrentGrabType() == GrabTypeFlags.Pinch)
        {
            if (handGrabInteractorL.IsGrabbing) 
            {
                grabPincetteTime += Time.deltaTime;

                if (grabPincetteTime > 3.0f)
                {
                    GrabbedPincette.SetActive(true);
                    pincette.SetActive(false);
                }
            }
        }
        else if (handGrabInteractorL.CurrentGrabType() == GrabTypeFlags.Palm)
        {
            grabPincetteTime = 0;
            GrabbedPincette.SetActive(false);
            pincette.SetActive(true);
        }

    }


}

            // Grabbed ������ ��
            /*if (handGrabInteractorL.IsGrabbing)
            {
                state = State.Grabbed;
            }
            // Released ������ ��
            else
            {
                state = State.Released;
            }*/
