using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    public Action<int, int> TimeUpdate;

    private Text _text;

    private float _time;
    private float _highScore;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _time += Time.deltaTime;
        _text.text = $": {Mathf.Floor(_time)}s";

        ChangeHighRecord();

        TimeUpdate?.Invoke((int)_time, (int)_highScore);
    }

    private void ChangeHighRecord()
    {
        if (_time >= _highScore)
        {
            int i = Mathf.RoundToInt(_time);
            PlayerPrefs.SetInt("HighScore", i);
        }
    }
}
