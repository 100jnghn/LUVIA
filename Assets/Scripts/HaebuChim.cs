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

    // OneGrabFreeTransformer의 메소드 override
    // 이 물체를 잡을 때 호출됨
    public new void BeginTransform()
    {
        isGrabbed = true;

        base.BeginTransform();
        onobjectGrabbed?.Invoke(gameObject);

        detectGrab(); // 잡았을 때 detectGrab() 호출
    }

    // OneGrabFreeTransformer의 메소드 override
    // 이 물체를 잡고 이동시킬 때마다 호출됨
    public new void UpdateTransform()
    {
        base.UpdateTransform();
        onObjectMoved?.Invoke(gameObject);
    }

    // OneGrabFreeTransformer의 메소드 override
    // 이 물체를 잡았다가 놓았을 때 호출됨
    public new void EndTransform()
    {
        isGrabbed = false;

        onObjectReleased?.Invoke(gameObject);

        detectGrab(); // detectGrab()을 호출함
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
}
