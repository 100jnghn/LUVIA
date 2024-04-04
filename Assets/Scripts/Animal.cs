using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : OneGrabFreeTransformer, ITransformer
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

    public delegate void ObjectGrabbed(GameObject source);
    public event ObjectGrabbed onobjectGrabbed;

    public delegate void ObjectMoved(GameObject source);
    public event ObjectMoved onObjectMoved;

    public delegate void ObjectReleased(GameObject source);
    public event ObjectReleased onObjectReleased;

    private Animator animator;

    public bool isGrabbed;  // �������� �տ� ���� ��������
    public bool isAnesed;   // �������� ����� ��������

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
        state = FrogState.Idle;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        checkState(); // ���� üũ
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

    void checkState()
    {
        if (state == FrogState.Idle)
        {
            // Idle Action
        }
        else if (state == FrogState.Grabbed)
        {
            // ������ �� Action
            frogGrabbed();
        }
        else if (state == FrogState.Anesthesia)
        {
            // ������� �� Action
        }
    }

    public void frogGrabbed()
    {
        
    }

    public void doAnes()
    {
        state = FrogState.Anesthesia;

        // ���� �ƴ��� Ȯ���ϱ� ���� ����� �뵵�� ũ�� Ű���
        gameObject.transform.localScale += new Vector3(2f, 2f, 2f);
    }
}
