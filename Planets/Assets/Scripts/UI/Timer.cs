using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] private float highScore;
    private Text _text;
    public Text _highScoreText;
    public float _time;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore1");
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _time += Time.deltaTime;

        _text.text = $": {Mathf.Floor(_time)}s";

        ChangeHighRecord();
    }

    private void ChangeHighRecord()
    {
        _highScoreText.text = highScore.ToString();

        if (_time >= highScore)
        {
            int i = Mathf.RoundToInt(_time);
            PlayerPrefs.SetInt("HighScore1", i);
        }
    }
}
