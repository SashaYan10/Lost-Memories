using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorHandle : MonoBehaviour
{
    public Image handle;
    public GameObject objDelete;
    public GameObject objAct;
    public GameObject objSound;
    public float speed = 1f;
    private bool isRotated = false;
    private Vector3 previousMousePosition;
    private bool isDragging = false;

    public bool allowClockwise = true;
    public bool allowCounterClockwise = false;

    private float currentAngle = 0f;

    public AudioClip lockSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverHandle())
            {
                isDragging = true;
                previousMousePosition = Input.mousePosition;
            }
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 delta = currentMousePosition - previousMousePosition;

            float rotationAmount = delta.x * speed;

            float newAngle = currentAngle - rotationAmount;

            if ((rotationAmount > 0 && allowClockwise) || (rotationAmount < 0 && allowCounterClockwise))
            {
                float clampedAngle = Mathf.Clamp(newAngle, 0f, 180f);

                if ((clampedAngle == 0f || clampedAngle == 180f) && currentAngle != clampedAngle)
                {
                    PlayLockSound();
                }

                currentAngle = clampedAngle;
                handle.transform.localEulerAngles = new Vector3(0, 0, currentAngle);
            }

            previousMousePosition = currentMousePosition;

            if (!isRotated && Mathf.Abs(currentAngle - 180) < 1f)
            {
                ActDelete();
                isRotated = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private bool IsMouseOverHandle()
    {
        RectTransform rectTransform = handle.rectTransform;
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);
        return rectTransform.rect.Contains(localMousePosition);
    }

    private void ActDelete()
    {
        if (objDelete != null)
        {
            Destroy(objDelete);
        }

        if (objAct != null)
        {
            objAct.SetActive(true);
        }

        if (objSound != null)
        {
            objSound.SetActive(true);
        }
    }

    private void PlayLockSound()
    {
        if (lockSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(lockSound);
        }
    }
}
