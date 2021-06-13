using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    [SerializeField] private Timer timer;

    [Header("Time Fields")]
    [SerializeField] private Text currentTime;
    [SerializeField] private Text highTime;

    private void OnEnable()
    {
        timer.TimeUpdate += UpdateTimeText;
    }

    private void OnDisable()
    {
        timer.TimeUpdate -= UpdateTimeText;
    }

    private void UpdateTimeText(int currentTime, int highTime)
    {
        this.currentTime.text = $": {currentTime}";
        this.highTime.text = $": {highTime}";
    }
}
