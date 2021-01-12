using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class StartMenu : CanvasMV
{
    private string _startButtonText;

    [SerializeField] private Sprite _startButtonIcon;

    [Binding]
    public Sprite StartButtonIcon
    {
        get => this._startButtonIcon;

        set
        {
            if (this._startButtonIcon == value)
                return;

            this._startButtonIcon = value;

            OnPropertyChanged();
        }
    }

    [Binding]
    public string StartButtonText
    {
        get => this._startButtonText;

        set
        {
            if (this._startButtonText == value)
                return;

            this._startButtonText = value;

            OnPropertyChanged();
        }
    }

    [Binding]
    public void OnStartClicked()
    {
        Debug.Log("Start Clicked!");
    }

    private void Start()
    {
        StartButtonText = "Start The Battle";
    }
}
