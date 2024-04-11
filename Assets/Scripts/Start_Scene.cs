using UnityEngine;
using UnityEngine.UI;

public class Start_Scene : MonoBehaviour
{
    public Canvas canvasToDisable;
    public Camera mainCamera;
    public float cameraMoveSpeed = 5f;
    public float canvasFadeSpeed = 2f;

    private bool isButtonClicked = false;

    // �ʱ� ī�޶��� ��ġ�� ȸ���� �����ϴ� ����
    private Vector3 initialCameraPosition = new Vector3(0, 1, 0);
    private Quaternion initialCameraRotation = Quaternion.Euler(0, 0, 0);

    // �̵��� ��ġ�� ȸ���� ����
    public Vector3 targetPosition = new Vector3(0, 1.5f, 0);
    public Quaternion targetRotation = Quaternion.Euler(42, 0, 0);

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ �߰�
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);

        // ī�޶��� �ʱ� ��ġ�� ȸ���� ����
        initialCameraPosition = mainCamera.transform.position;
        initialCameraRotation = mainCamera.transform.rotation;
    }

    void Update()
    {
        // ��ư�� Ŭ���Ǹ� ĵ������ ������ ��Ȱ��ȭ�ϰ� ī�޶� ������ ��ġ�� �̵���Ŵ
        if (isButtonClicked)
        {
            // ĵ������ ������ ��Ȱ��ȭ
            canvasToDisable.gameObject.SetActive(false);

            // ī�޶� ������ �̵���Ŵ
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, targetRotation, cameraMoveSpeed * Time.deltaTime);

            // �̵��� �Ϸ�Ǹ� ĵ������ ������ ��Ȱ��ȭ�ϰ� �̵��� �ߴ�
            if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 0.01f)
            {
                canvasToDisable.gameObject.SetActive(false);
                isButtonClicked = false;
            }
        }
    }

    void OnButtonClick()
    {
        // ��ư�� Ŭ���Ǹ� �̵� ����
        isButtonClicked = true;
    }

    // ���� ���ε�� �� ī�޶��� �ʱ� ��ġ�� ȸ������ ����
    void OnEnable()
    {
        mainCamera.transform.position = initialCameraPosition;
        mainCamera.transform.rotation = initialCameraRotation;
    }
}
