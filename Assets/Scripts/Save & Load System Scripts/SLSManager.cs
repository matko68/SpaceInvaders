using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SLSManager : MonoBehaviour
{

    #region SAVE & LOAD SYSTEM MANAGER PROPERTY

    private static SLSManager _selfSLSM;

    public static SLSManager SLSM
    {
        get
        {

            if (_selfSLSM == null)
            {
                _selfSLSM = FindObjectOfType<SLSManager>();
                if (_selfSLSM != null)
                    _selfSLSM.LoadStats();
            }

            return _selfSLSM;

        }
    }

    #endregion

    #region STATS PROPERTY

    [SerializeField]

    private Stats stats;

    public Stats Stats
    {
        get
        {
            return stats;
        }
    }

    #endregion

    private void Awake()
    {

        if (_selfSLSM == null)
            _selfSLSM = this;

        if (_selfSLSM != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    public void LoadStats()
    {
        stats = BinarySerializer.LoadStats();
    }

    public void SaveStats()
    {
        BinarySerializer.SaveStats(stats);
        LoadStats();
    }

    public void UpdateStats(int stage, int score)
    {
        stats = new Stats(stage, score);
    }

}