using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // EventTrigger�� ����ϱ� ���� �߰�

public class Start_Scene : MonoBehaviour
{
    public Canvas canvasToDisable; // ��Ȱ��ȭ�� ĵ����

    void Start()
    {
        // �̺�Ʈ Ʈ���Ÿ� �����ͼ� �̺�Ʈ ������ �߰�
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick; // ��ư Ŭ�� �̺�Ʈ
        entry.callback.AddListener((data) => { OnButtonClicked(); }); // �ݹ� �Լ� ���
        trigger.triggers.Add(entry);
    }

    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    void OnButtonClicked()
    {
        // ĵ������ ��Ȱ��ȭ
        canvasToDisable.gameObject.SetActive(false);
    }
}
