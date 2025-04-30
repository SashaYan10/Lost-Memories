using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hammer : MonoBehaviour
{
    public Animator animator;
    private RectTransform rectTransform;
    private bool isClickBlocked = false;
    private float blockDuration = 1.45f;
    public List<GameObject> normalCursorObjects;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent as RectTransform,
            Input.mousePosition,
            null,
            out mousePos);

        rectTransform.anchoredPosition = mousePos;

        bool isOverNormalCursorObject = false;
        foreach (GameObject obj in normalCursorObjects)
        {
            if (obj.activeInHierarchy && RectTransformUtility.RectangleContainsScreenPoint(obj.GetComponent<RectTransform>(), Input.mousePosition))
            {
                isOverNormalCursorObject = true;
                break;
            }
        }

        UnityEngine.Cursor.visible = isOverNormalCursorObject;
        gameObject.SetActive(!isOverNormalCursorObject);

        if (Input.GetMouseButtonDown(0) && !isClickBlocked && !isOverNormalCursorObject)
        {
            animator.SetTrigger("Hit");
            StartCoroutine(BlockClicks());
        }
    }

    private IEnumerator BlockClicks()
    {
        isClickBlocked = true;
        yield return new WaitForSeconds(blockDuration);
        isClickBlocked = false;
    }
}