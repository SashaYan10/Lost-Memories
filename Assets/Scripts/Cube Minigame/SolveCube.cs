using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kociemba;

public class SolveCube : MonoBehaviour
{
    private ReadCube readCube;
    private CubeState cubeState;
    private bool doOnce = true;

    void Start()
    {
        readCube = FindObjectOfType<ReadCube>();
        cubeState = FindObjectOfType<CubeState>();
    }

    public void StartSolver()
    {
        if (doOnce)
        {
            doOnce = false;
            Solver();
        }
    }

    private void Solver()
    {
        readCube.ReadState();

        string moveString = cubeState.GetStateString();
        print(moveString);

        string info = "";
        string solution = Search.solution(moveString, out info);

        List<string> solutionList = StringToList(solution);

        Automate.moveList = solutionList;
        print(info);
    }

    private List<string> StringToList(string solution)
    {
        List<string> solutionList = new List<string>(solution.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
        return solutionList;
    }
}
