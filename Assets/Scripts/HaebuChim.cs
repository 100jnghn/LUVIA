using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaebuChim : OneGrabFreeTransformer, ITransformer
{
    public delegate void ObjectGrabbed(GameObject source);
    public event ObjectGrabbed onobjectGrabbed;

    public delegate void ObjectMoved(GameObject source);
    public event ObjectMoved onObjectMoved;

    public delegate void ObjectReleased(GameObject source);
    public event ObjectReleased onObjectReleased;



    public HandGrabInteractor handGrabInteractorR;

    MeshRenderer meshRenderer;
    bool isGrabbed;

    public new void Initialize(IGrabbable grabbable)
    {
        base.Initialize(grabbable);
    }

    // OneGrabFreeTransformer�� �޼ҵ� override
    // �� ��ü�� ���� �� ȣ���
    public new void BeginTransform()
    {
        isGrabbed = true;

        base.BeginTransform();
        onobjectGrabbed?.Invoke(gameObject);

        detectGrab(); // ����� �� detectGrab() ȣ��
    }

    // OneGrabFreeTransformer�� �޼ҵ� override
    // �� ��ü�� ��� �̵���ų ������ ȣ���
    public new void UpdateTransform()
    {
        base.UpdateTransform();
        onObjectMoved?.Invoke(gameObject);
    }

    // OneGrabFreeTransformer�� �޼ҵ� override
    // �� ��ü�� ��Ҵٰ� ������ �� ȣ���
    public new void EndTransform()
    {
        isGrabbed = false;

        onObjectReleased?.Invoke(gameObject);

        detectGrab(); // detectGrab()�� ȣ����
    }

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();   
    }

    void Update()
    {
        
    }

    void detectGrab()
    {
        
        if(isGrabbed)
        {
            meshRenderer.material.color = Color.black;
        }
        else
        {
            meshRenderer.material.color = Color.white;
        }
    }

    // isKinematic�� true�� �غ�ħ�� ������ ������ collider�� �۵����� �ʾƼ� trigger�� �ϴ� ó����
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Organ"))
        {
            OrganDescription description = other.gameObject.GetComponent<OrganDescription>();
            description.setActiveUI();
        }
    }*/

    // isKenematic�� false�� �غ�ħ
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Organ"))
        {
            OrganDescription description = collision.gameObject.GetComponent<OrganDescription>();
            description.setActiveUI();
        }
    }
}
