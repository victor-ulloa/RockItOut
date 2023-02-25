using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Singelton<GameManager>
{
    [HideInInspector] public UnityEvent<int> OnScoreValueChanged;

    [SerializeField] public PlayerController player;

    private int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreValueChanged.Invoke(_score);
            Debug.Log("Your score is:" + score.ToString());
        }
    }

    public void RestartLevel()
    {
        score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
