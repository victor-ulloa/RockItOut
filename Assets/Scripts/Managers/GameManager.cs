using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singelton<GameManager>
{
    private int _score = 0;
    public int score {
        get { return _score; }
        set {
            _score = value;
            Debug.Log("Your score is:" + score.ToString());
        }
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
