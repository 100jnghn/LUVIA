using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jusagi : OneGrabFreeTransformer, ITransformer
{

    public delegate void ObjectGrabbed(GameObject source);
    public event ObjectGrabbed onobjectGrabbed;

    public delegate void ObjectMoved(GameObject source);
    public event ObjectMoved onObjectMoved;

    public delegate void ObjectReleased(GameObject source);
    public event ObjectReleased onObjectReleased;

    public bool isGrabbed;
    public float collisionDuration;

    public GameObject imageObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

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

    void detectGrab()
    {

        if (isGrabbed)
        {

        }
        else
        {

        }
    }



    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Animal"))
        {
            Animal cshAnimal = collision.gameObject.GetComponent<Animal>();

            // collision�� 'Animal'�̰� �����ִ� ���¶��
            if(cshAnimal.isGrabbed)
            {
                // ���� ���·� �����ϴ� �Լ� ȣ��
                cshAnimal.doAnes();
            }
        }
    }*/

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Animal"))
        {
            collisionDuration += Time.deltaTime;
            
            if(collisionDuration > 3f)
            {
                Animal cshAnimal = collision.gameObject.GetComponent<Animal>();
                cshAnimal.doAnes();
                imageObject.SetActive(true);
            }
        }
    }
}
