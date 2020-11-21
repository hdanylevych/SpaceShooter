using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class StartMenu : MonoBehaviour, INotifyPropertyChanged
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

            OnPropertyChanged("StartButtonIcon");
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

            OnPropertyChanged("StartButtonText");
        }
    }

    [Binding]
    public void OnStartClicked()
    {
        Debug.Log("Start Clicked!");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void Start()
    {
        StartButtonText = "Start The Battle";
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
