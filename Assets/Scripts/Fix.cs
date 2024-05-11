using Oculus.Interaction;
using UnityEngine;

public class Fix : MonoBehaviour
{
    public GameObject objectPrefab; // ������ ��ü ������
    public Transform spawnPoint1; // ��ü�� ������ ��ġ1 (���� ��)
    public Transform spawnPoint2; // ��ü�� ������ ��ġ2 (������ ��)
    public Transform spawnPoint3; // ��ü�� ������ ��ġ3 (������ �ٸ�)
    public Transform spawnPoint4; // ��ü�� ������ ��ġ4 (���� �ٸ�)



    // �������� �������̶� �浹���� �� ������ �̵�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal") && objectPrefab != null && spawnPoint1 != null && spawnPoint2 != null && spawnPoint3 != null && spawnPoint4 != null)
        {
            // ù ��° ���� ��ġ�� ��ü�� ����
            Instantiate(objectPrefab, spawnPoint1.position, spawnPoint1.rotation);
            // �� ��° ���� ��ġ�� ��ü�� ����
            Instantiate(objectPrefab, spawnPoint2.position, spawnPoint2.rotation);
            // ù ��° ���� ��ġ�� ��ü�� ����
            Instantiate(objectPrefab, spawnPoint3.position, spawnPoint3.rotation);
            // �� ��° ���� ��ġ�� ��ü�� ����
            Instantiate(objectPrefab, spawnPoint4.position, spawnPoint4.rotation);

            // �� ������Ʈ ��ü�� ����
            Destroy(gameObject);
        }
    }
}
