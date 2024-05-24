using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade_out : MonoBehaviour
{
    public GameObject imageObject;
    public float delayTime = 3f; // �̹����� Ȱ��ȭ�� �� ��Ȱ��ȭ�� �������� ��� �ð�
    public float fadeDuration = 1f; // �̹����� ������ ������� �� �ɸ��� �ð�

    private Image imageComponent;

    void Start()
    {
        // �̹��� ������Ʈ�� Image ������Ʈ�� �ִ��� Ȯ��
        imageComponent = imageObject.GetComponent<Image>();
        if (imageComponent == null)
        {
            Debug.LogError("Image component not found on the imageObject.");
            return;
        }

        // �̹����� Ȱ��ȭ�� ��쿡�� ������ �ð� �Ŀ� ��Ȱ��ȭ�ϴ� �ڷ�ƾ ����
        if (imageObject.activeSelf)
        {
            StartCoroutine(DisableImageAfterDelay(delayTime));
        }
    }

    // ���� �ð��� ���� �Ŀ� �̹����� ������ ��Ȱ��ȭ�ϴ� �ڷ�ƾ
    IEnumerator DisableImageAfterDelay(float delay)
    {
        // delay �ð���ŭ ���
        yield return new WaitForSeconds(delay);

        // �̹��� ������ ������� �ϱ�
        yield return StartCoroutine(FadeOut(imageComponent, fadeDuration));

        // �̹��� ��Ȱ��ȭ
        imageObject.SetActive(false);
    }

    // ���� ���� ������ �ٿ��� �̹����� ������ ������� �ϴ� �ڷ�ƾ
    IEnumerator FadeOut(Image image, float duration)
    {
        Color startColor = image.color;
        float rate = 1.0f / duration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            image.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(startColor.a, 0, progress));
            progress += rate * Time.deltaTime;
            yield return null;
        }

        image.color = new Color(startColor.r, startColor.g, startColor.b, 0);
    }
}
