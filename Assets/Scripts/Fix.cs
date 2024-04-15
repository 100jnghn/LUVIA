using Oculus.Interaction;
using UnityEngine;

public class Fix : OneGrabFreeTransformer, ITransformer
{
    public GameObject objectPrefab; // ������ ��ü ������
    public Transform spawnPoint1; // ��ü�� ������ ��ġ1
    public Transform spawnPoint2; // ��ü�� ������ ��ġ2

    public delegate void ObjectGrabbed(GameObject source);
    public event ObjectGrabbed onobjectGrabbed;

    public delegate void ObjectMoved(GameObject source);
    public event ObjectMoved onObjectMoved;

    public delegate void ObjectReleased(GameObject source);
    public event ObjectReleased onObjectReleased;

    public bool isGrabbed;

    public new void Initialize(IGrabbable grabbable)
    {
        base.Initialize(grabbable);
    }

    // �� ��ü�� ���� �� ȣ���
    public new void BeginTransform()
    {
        isGrabbed = true;

        base.BeginTransform();
        onobjectGrabbed?.Invoke(gameObject);

        detectGrab(); // ����� �� detectGrab() ȣ��
    }

    // �� ��ü�� ��� �̵���ų ������ ȣ���
    public new void UpdateTransform()
    {
        base.UpdateTransform();
        onObjectMoved?.Invoke(gameObject);
    }

    // �� ��ü�� ��Ҵٰ� ������ �� ȣ���
    public new void EndTransform()
    {
        isGrabbed = false;

        onObjectReleased?.Invoke(gameObject);

        detectGrab(); // detectGrab()�� ȣ����
    }

    void detectGrab()
    {
        // �ʿ��� ��쿡�� �߰����� ���� ����
    }

    // �������� �������̶� �浹���� �� ������ �̵�
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Fix") && objectPrefab != null && spawnPoint1 != null && spawnPoint2 != null)
        {
            // ù ��° ���� ��ġ�� ��ü�� ����
            Instantiate(objectPrefab, spawnPoint1.position, spawnPoint1.rotation);
            // �� ��° ���� ��ġ�� ��ü�� ����
            Instantiate(objectPrefab, spawnPoint2.position, spawnPoint2.rotation);

            Destroy(collision.collider.gameObject);

            // �� ������Ʈ ��ü�� ����
            Destroy(this);
        }
    }
}
