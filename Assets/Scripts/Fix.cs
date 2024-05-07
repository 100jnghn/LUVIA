using Oculus.Interaction;
using UnityEngine;

public class Fix : MonoBehaviour
{
    public GameObject objectPrefab; // ������ ��ü ������
    public Transform spawnPoint1; // ��ü�� ������ ��ġ1
    public Transform spawnPoint2; // ��ü�� ������ ��ġ2


    // �������� �������̶� �浹���� �� ������ �̵�
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Animal") && objectPrefab != null && spawnPoint1 != null && spawnPoint2 != null)
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
