using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MovingPuzzle : MonoBehaviour
{
    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;
    public GameObject form;
    bool finish;
    bool inCorrectPosition;

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            mousePos = Input.mousePosition;

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            inCorrectPosition = Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 10f &&
                                Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 10f;
        }
    }

    void OnMouseUp()
    {
        move = false;

        if (!inCorrectPosition && finish == false)
        {
            if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 10f &&
                Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 10f)
            {
                this.transform.localPosition = new Vector2(form.transform.localPosition.x, form.transform.localPosition.y);
                finish = true;
                WinScript.AddElement();
            }
        }
    }

    void Update()
    {
        if (move == true && finish == false)
        {
            mousePos = Input.mousePosition;

            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }
}
