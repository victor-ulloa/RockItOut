using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int maxLives = 5;


    private int _lives = 3;
    public int lives {
        get { return _lives; }
        set {

            if (_lives > value) {
                // lost 1 live
            }

            if (value <= 0) {
                // died
            }

            _lives = value;
            if (_lives > maxLives) {
                _lives = maxLives;
            }
            Debug.Log("Lives are set to:" + lives.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
