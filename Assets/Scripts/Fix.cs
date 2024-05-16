using Oculus.Interaction;
using UnityEngine;

public class Fix : MonoBehaviour
{
    public GameObject objectPrefab; // ������ ��ü ������
    public Transform[] spawnPoints;
    public GameObject[] imageObject;

    private int spawnIndex = 0;

    // �������� �������̶� �浹���� �� ������ �̵�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal") && objectPrefab != null && spawnIndex < spawnPoints.Length)
        {
            // ���� �ε����� �ش��ϴ� ��ġ�� ��ü�� ����
            Instantiate(objectPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
            imageObject[spawnIndex].SetActive(true);

            // ���� �ε����� �̵�
            spawnIndex++;

            if (spawnIndex > 4)
            {
                Destroy(gameObject);
            }
        }
    }
}
