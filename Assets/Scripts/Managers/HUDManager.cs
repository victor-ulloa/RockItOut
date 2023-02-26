using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TMP_Text livesValue;
    [SerializeField] TMP_Text scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        if (livesValue)
        {
            livesValue.text = GameManager.Instance.player.lives.ToString();
            GameManager.Instance.player.OnLifeValueChaged.AddListener((value) => UpdateLives(value));
        }
        if (scoreValue)
        {
            scoreValue.text = GameManager.Instance.score.ToString();
            GameManager.Instance.OnScoreValueChanged.AddListener((value) => UpdateScore(value));
        }
    }

    void UpdateLives(int value)
    {
        livesValue.text = value.ToString();
    }

    void UpdateScore(int value)
    {
        scoreValue.text = value.ToString();
    }
}
