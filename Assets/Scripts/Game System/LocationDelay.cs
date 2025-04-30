using System.Collections;
using UnityEngine;

public class LocationDelay : MonoBehaviour
{
    public GameObject location;
    public GameObject currentLocation;
    public GameObject blackScreen;
    public float delayShow = 1f;
    public float delayHide = 1f;
    public float delayHideBlackScreen = 2f;

    private void OnEnable()
    {
        StartCoroutine(ManageLocationTransitions());
    }

    private IEnumerator ManageLocationTransitions()
    {
        blackScreen.SetActive(true);

        yield return new WaitForSeconds(delayHide);
        currentLocation.SetActive(false);

        yield return new WaitForSeconds(delayShow);
        location.SetActive(true);

        yield return new WaitForSeconds(delayHideBlackScreen);
        blackScreen.SetActive(false);
    }
}
