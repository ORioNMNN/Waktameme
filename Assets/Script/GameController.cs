using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private UIController        uiController;
    [SerializeField]
    private PatternPlayer       patternPlayer;
    [SerializeField]
    private CharController      charController;

    private readonly float scoreScale = 20; // ???? ???? ???? (????????)

    //???????? ???? (???????? ???? ????)
    public float CurrentScore  { private set; get; } = 0;

    public bool  IsGamePlay { private set; get; } = false;

    public void GameStart()
    {
        uiController.GameStart();

        patternPlayer.GameStart();

        charController.good();
        IsGamePlay = true;
    }

    public void GameExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif

    }

    public void GameOver()
    {

        uiController.GameOver();

        patternPlayer.GameOver();

        IsGamePlay = false;

    }

    public void Shop()
    {
        uiController.GoShop();
    }
    
    private void Update()
    {
        if (IsGamePlay == false) return;
        CurrentScore += Time.deltaTime * scoreScale;

    }
 
}
