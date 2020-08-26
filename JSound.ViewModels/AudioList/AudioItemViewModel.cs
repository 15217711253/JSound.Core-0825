using System;
using GalaSoft.MvvmLight;
using JSound.Models;

public class AudioItemViewModel : ViewModelBase, IDisposable
{
    public AudioItemViewModel(XAudio audio)
    {
        Audio = audio;
        IsSelected = false;
    }

    private XAudio _audio;

    public XAudio Audio
    {
        get { return _audio; }
        set
        {
            _audio = value;
            this.RaisePropertyChanged("Audio");
        }
    }

    private bool _isSelected;

    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            _isSelected = value;
            this.RaisePropertyChanged("IsSelected");
        }
    }


    public void Dispose()
    {
        throw new NotImplementedException();
    }
}