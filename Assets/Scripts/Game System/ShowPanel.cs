using UnityEngine;
using UnityEngine.EventSystems;

public class ShowPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject panel;
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
        return panel.GetComponent<CanvasGroup>().alpha;
    }

    private void SetButtonAlpha(float alpha)
    {
        panel.GetComponent<CanvasGroup>().alpha = alpha;
    }
}
