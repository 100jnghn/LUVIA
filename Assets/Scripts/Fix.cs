using Oculus.Interaction;
using UnityEngine;

public class Fix : MonoBehaviour
{
    public GameObject objectPrefab; // ������ ��ü ������
    //public Transform[] spawnPoints;
    public GameObject[] imageObject;
    public Transform spawnPoints1;
    public Transform spawnPoints2;
    public Transform spawnPoints3;
    public Transform spawnPoints4;


    // �������� �������̶� �浹���� �� ������ �̵�
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal") && objectPrefab != null)
        {
            Debug.Log("OK");

            // ���� �ε����� �ش��ϴ� ��ġ�� ��ü�� ����
            Instantiate(objectPrefab, spawnPoints1.position, spawnPoints1.rotation);
            Instantiate(objectPrefab, spawnPoints2.position, spawnPoints2.rotation);
            Instantiate(objectPrefab, spawnPoints3.position, spawnPoints3.rotation);
            Instantiate(objectPrefab, spawnPoints4.position, spawnPoints4.rotation);

            //imageObject[spawnIndex].SetActive(true);


        }
    }
}
