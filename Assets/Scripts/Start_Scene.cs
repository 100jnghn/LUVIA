using UnityEngine;

public class Start_Scene : MonoBehaviour
{
    public Canvas canvasToDisable; // ��Ȱ��ȭ�� ĵ����

    private void OnTriggerEnter(Collider collision)
    {
        canvasToDisable.gameObject.SetActive(false);
    }
}
