using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //public var
    public static ScoreManager scoreManagerIstance;
    public int m_score;
    
    
    //references
    [SerializeField]
    private Text m_scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreManagerIstance = this;
        m_scoreText.text = "" + m_score;
    }
    
    public void addScore()
    {
        m_score++;

        ChangeText();
    }

    void ChangeText()
    {
        m_scoreText.text = "" + m_score;
    }
}
