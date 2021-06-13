using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class AudioEnableButton : MonoBehaviour
{
    [SerializeField] private AudioListener audioListener;

    [Header("Sprites")]
    [SerializeField] private Sprite audioEnabledSprite;
    [SerializeField] private Sprite audioDesabledSprite;

    private Button _button;
    private Image _image;

    private bool _audioEnable
    {
        get { return audioListener.enabled; }

        set { audioListener.enabled = value; }
    }

    #region Mono
    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();

        _button.image = _image;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }
    #endregion

    private void OnClick()
    {
        ToggleAudioState();
    }

    private void ToggleAudioState()
    {
        _audioEnable = !_audioEnable;

        SetButtonIcon();
    }

    private void SetButtonIcon()
    {
        if (_audioEnable)
            SetImage(audioEnabledSprite);
        else
            SetImage(audioDesabledSprite);
    }

    private void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
