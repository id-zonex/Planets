using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TemperatureProgressBar : MonoBehaviour
{
    [SerializeField] private float maxTemperature = 500;

    [SerializeField] private Planet target;

    private Image _progressBar;

    private void Start()
    {
        _progressBar = GetComponent<Image>();

        target.ChangeTemperature += OnChangeTemperature;
    }

    private void OnChangeTemperature(float temperature)
    {
        _progressBar.fillAmount = Mathf.Abs(temperature) / maxTemperature;
    }
}
