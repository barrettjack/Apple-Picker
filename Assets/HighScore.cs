using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;
    private Text textCom;

    void Awake() // awake is called when an instance of HighScore is first created, and before calling Start()
    {
        _UI_TEXT = GetComponent<Text>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", SCORE); // might seem weird, but we do this so that in the event that the pref doesn't
        // already exist, we set it.
    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value); // the only place this private setter is called is in the branch of TRY_SET_HIGH_SCORE
            // where the score is indeed a new high score.
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE)
        {
            return;
        }
        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs.")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos() // this method is called pretty much constantly, even when the game isn't running!
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore has been reset to 1000.");
        }
    }
}
