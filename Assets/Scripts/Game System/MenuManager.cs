using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;

    [Header("Pause Objects")]
    [SerializeField] private GameObject[] _dialogueMenuGO;

    [Header("Player Scripts to Deactivate on Pause")]
    [SerializeField] private PlayerMovement[] _playerMovements;

    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;
    [SerializeField] private GameObject _settingsMenuFirst;
    [SerializeField] private GameObject[] _dialogueMenuFirst;

    [Header("Action Object")]
    [SerializeField] private ActionObject[] actionObject;

    [Header("Objects That Prevent Pause")]
    [SerializeField] private GameObject[] activeNoPauseObjects;

    private bool isPaused;
    void Start()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
        foreach (var dialogueMenuGO in _dialogueMenuGO)
        {
            dialogueMenuGO.SetActive(false);
        }
    }

    private void Update()
    {
        if (InputUIManager.instance.MenuOpenCloseInput && CanPause())
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }

        for (int i = 0; i < actionObject.Length; i++)
        {
            if (actionObject != null && actionObject[i].DialogueActive() && !isPaused)
            {
                ShowDialogueMenu(i);
                break;
            }
        }
    }

    #region Pause/Unpause Functions

    public void Pause()
    {
        if (!CanPause()) return;

        isPaused = true;
        Time.timeScale = 0f;

        foreach (var playerMovement in _playerMovements)
        {
            playerMovement.enabled = false;
        }

        OpenMainMenu();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        foreach (var playerMovement in _playerMovements)
        {
            playerMovement.enabled = true;
        }

        CloseAllMenus();
    }

    private bool CanPause()
    {
        foreach (var obj in activeNoPauseObjects)
        {
            if (obj.activeSelf)
                return false;
        }
        return true;
    }

    #endregion

    #region Dialogue Menu Functions

    private void ShowDialogueMenu(int dialogueIndex)
    {
        isPaused = true;
        Time.timeScale = 0f;

        foreach (var playerMovement in _playerMovements)
        {
            playerMovement.enabled = false;
        }

        for (int i = 0; i < _dialogueMenuGO.Length; i++)
        {
            _dialogueMenuGO[i].SetActive(i == dialogueIndex);
            if (_dialogueMenuFirst.Length > i && i == dialogueIndex)
            {
                EventSystem.current.SetSelectedGameObject(_dialogueMenuFirst[i]);
            }
        }
    }

    public void CloseDialogueMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;

        foreach (var playerMovement in _playerMovements)
        {
            playerMovement.enabled = true;
        }

        foreach (var dialogueMenuGO in _dialogueMenuGO)
        {
            dialogueMenuGO.SetActive(false);
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion

    #region Canvas Activations/Deactivations

    private void OpenMainMenu()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    private void OpenSettingsMenuHandle()
    {
        _settingsMenuCanvasGO.SetActive(true);
        _mainMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }

    private void CloseAllMenus()
    {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
        foreach (var dialogueMenuGO in _dialogueMenuGO)
        {
            dialogueMenuGO.SetActive(false);
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion

    #region Dialogue Menu Button Actions

    public void OnDialogueNoPress()
    {
        CloseDialogueMenu();
    }

    #endregion

    #region Main Menu Button Actions

    public void OnSettingsPress()
    {
        OpenSettingsMenuHandle();
    }

    public void OnResumePress()
    {
        Unpause();
    }

    #endregion

    #region Settings Menu Button Actions

    public void OnSettingsBackPress()
    {
        OpenMainMenu();
    }

    #endregion
}
