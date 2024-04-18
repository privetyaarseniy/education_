using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button noButton;
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button myNumberButton;
    [SerializeField]
    private TextMeshProUGUI textCloud;

    private int _guess;
    private int _upperLimit = 100;
    private int _lowerLimit = 0;
    private bool _lessThanGuess;

    private void Start()
    {
        Guess();

        noButton.onClick.AddListener(delegate { ChangeLimits(!_lessThanGuess); });
        yesButton.onClick.AddListener(delegate { ChangeLimits(_lessThanGuess); });
        myNumberButton.onClick.AddListener(GameEnd);
    }

    private void Guess()
    {
        _guess = Random.Range(_lowerLimit, _upperLimit + 1);
        _lessThanGuess = Random.Range(0, 2) > 0;
        if(_lessThanGuess)
        {
            textCloud.text = $"Your number is less than {_guess}";
        }
        else
        {
            textCloud.text = $"Your number is more than {_guess}";
        }

        Debug.Log("Tried to guess");
    }

    private void ChangeLimits(bool lessThanGuess)
    {
        if(lessThanGuess)
        {
            _upperLimit = _guess - 1;
        }
        else
        {
            _lowerLimit = _guess + 1;
        }

        Debug.Log("Limits changed");
        Guess();
    }

    private void GameEnd()
    {
        Application.Quit();
    }
}
