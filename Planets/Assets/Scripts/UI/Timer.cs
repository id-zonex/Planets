using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    private Text _text;
    private float _time;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _time += Time.deltaTime;

        _text.text = $": {Mathf.Floor(_time).ToString()}s" ;
    }
}
