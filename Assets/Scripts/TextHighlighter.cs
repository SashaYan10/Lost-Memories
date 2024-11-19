using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TextHighlighter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text textComponent;
    private Vector3 originalScale;
    public float scaleFactor = 1.1f; // Фактор збільшення розміру
    public float animationDuration = 0.2f; // Тривалість анімації

    private Coroutine currentAnimation;

    void Start()
    {
        // Отримуємо компонент Text
        textComponent = GetComponent<Text>();

        // Зберігаємо оригінальний розмір тексту
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Зупиняємо попередню корутину, якщо вона вже запущена
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
        }

        // Запускаємо корутину для плавної анімації
        currentAnimation = StartCoroutine(SmoothScaleChange(originalScale * scaleFactor));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Зупиняємо попередню корутину, якщо вона вже запущена
        if (currentAnimation != null)
        {
            StopCoroutine(currentAnimation);
        }

        // Запускаємо корутину для плавної анімації зі зменшенням розміру
        currentAnimation = StartCoroutine(SmoothScaleChange(originalScale));
    }

    private IEnumerator SmoothScaleChange(Vector3 targetScale)
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Mathf.Clamp01(elapsedTime / animationDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale; // Забезпечуємо точне значення в кінці анімації
    }
}
