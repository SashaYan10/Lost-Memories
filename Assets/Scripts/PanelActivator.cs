using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    public GameObject panel;
    public string tagPlayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagPlayer))
        {
            panel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagPlayer))
        {
            panel.SetActive(false);
        }
    }
}
