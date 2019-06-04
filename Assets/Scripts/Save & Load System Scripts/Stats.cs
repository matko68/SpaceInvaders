using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Stats
{

    [Header("Read-Only")]

    [SerializeField]
    private int _stage;

    [SerializeField]
    private int _score;

    public Stats(int stage, int score)
    {
        this._stage = stage;
        this._score = score;
    }

    public Stats()
    {
    }

    public int GetStage()
    {
        return _stage;
    }

    public int GetScore()
    {
        return _score;
    }

}
