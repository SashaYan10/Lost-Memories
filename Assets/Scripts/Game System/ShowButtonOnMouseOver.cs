using UnityEngine;
using UnityEngine.EventSystems;

public class ShowButtonOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject button;
    public float smoothTime = 0.3f;

    private float targetAlpha = 0f;
    private float currentVelocity;

    void Start()
    {
        SetButtonAlpha(0f);
    }

    void Update()
    {
        float newAlpha = Mathf.SmoothDamp(GetButtonAlpha(), targetAlpha, ref currentVelocity, smoothTime);
        SetButtonAlpha(newAlpha);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetAlpha = 1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetAlpha = 0f;
    }

    private float GetButtonAlpha()
    {
        return button.GetComponent<CanvasGroup>().alpha;
    }

    private void SetButtonAlpha(float alpha)
    {
        button.GetComponent<CanvasGroup>().alpha = alpha;
    }
}
