using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SudokuManager : MonoBehaviour
{
    [System.Serializable]
    public class SudokuCell
    {
        public InputField inputField;
        public int number;

        public void SetupValidation()
        {
            inputField.onEndEdit.AddListener(delegate { ValidateInput(); });
        }

        private void ValidateInput()
        {
            if (string.IsNullOrEmpty(inputField.text)) return;

            int enteredNumber;
            bool isValid = int.TryParse(inputField.text, out enteredNumber);

            if (!isValid || enteredNumber != number)
            {
                Debug.Log("Not correct");
            }
            else
            {
                SudokuManager sudokuManager = inputField.GetComponentInParent<SudokuManager>();
                sudokuManager.CheckSudoku();
            }
        }
    }

    public List<SudokuCell> cells;
    public GameObject winPanel;

    void Start()
    {
        winPanel.SetActive(false);

        foreach (var cell in cells)
        {
            cell.SetupValidation();
        }
    }

    public void CheckSudoku()
    {
        foreach (var cell in cells)
        {
            if (string.IsNullOrEmpty(cell.inputField.text) || int.Parse(cell.inputField.text) != cell.number)
            {
                return;
            }
        }

        winPanel.SetActive(true);
    }
}
