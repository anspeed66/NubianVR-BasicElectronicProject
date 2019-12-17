using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct Answer
{
    [SerializeField] private string _info;
    public string Info { get{ return _info; } }

    [SerializeField] private bool _isCorrect;
    public bool IsCorrect { get { return _isCorrect; } }
}


public class Question : ScriptableObject
{
    public enum AnswerType { Multi, Single }

    [SerializeField] private string _info = string.Empty;
    public string Info { get { return _info; } }


    [SerializeField] Answer[] _answers = null;
    public Answer[] Answers { get { return _answers; } }

    //Parameters

    [SerializeField] private bool _useTimer = false;
    public bool UseTimer { get { return _useTimer; } }

    [SerializeField] private int _timer = 0;
    public int Timer { get { return _timer; } }

    [SerializeField] private AnswerType _answerType = AnswerType.Multi;
    public AnswerType GetAnswerType { get { return _answerType; } }

    public List<int> GetCorrectAnswers()
    {
        List<int> CorrectAnswers = new List<int>();
        for (int i = 0; i < Answers.Length; i++)
        {
            if (Answers[i].IsCorrect)
            {
                CorrectAnswers.Add(i);
            }
        }
        return CorrectAnswers;
    }

}
