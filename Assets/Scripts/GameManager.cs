using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StageDifficulty
{
    EASY,
    MEDIUM,
    HARD
}

public class GameManager : MonoBehaviour
{

    #region GAME MANAGER PROPERTY

    private static GameManager _GM;

    public static GameManager GM
    {
        get
        {
            if (_GM == null)
                _GM = FindObjectOfType<GameManager>();
            return (_GM);
        }
    }

    #endregion

    [HideInInspector]
    public bool InGame = false;

    private StageDifficulty _difficulty = StageDifficulty.MEDIUM;

    private void Awake()
    {

        if (_GM == null)
            _GM = this;

        if (_GM != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    private void GoToLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void GoToNextLevel()
    {
        // TODO: Write function.
    }

    #region METHODS FOR UI BUTTONS

    public void SetDifficultyHard()
    {
        _difficulty = StageDifficulty.HARD;
    }

    public void SetDifficultyMedium()
    {
        _difficulty = StageDifficulty.MEDIUM;
    }

    public void SetDifficultyEasy()
    {
        _difficulty = StageDifficulty.EASY;
    }

    public void ReturnToMenu()
    {
        GoToLevel(0);
    }

    public void NewGame()
    {
        GoToLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion

}
