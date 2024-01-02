using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour, IObservable<VoiceEnum>
{
    private VoiceEnum current_language;
    private List<IObserver<VoiceEnum>> voiceObserverList;

    public GameSettings()
    {
        voiceObserverList = new List<IObserver<VoiceEnum>>();
    }

    void Start()
    {
        InitializeLanguageSetting();        
    }

    private void InitializeLanguageSetting()
    {
        int languagePref = 0;
        if ( PlayerPrefs.HasKey( "Selected Language" ) )
        {
            languagePref = PlayerPrefs.GetInt( "Selected Language" );
        }
        else
        {
            PlayerPrefs.SetInt( "Selected Language", languagePref );
        }

        CURRENT_LANGUAGE = ParseLanguageInt( languagePref );
    }

    private VoiceEnum ParseLanguageInt( int languagePref )
    {
        VoiceEnum language;

        switch ( languagePref )
        {
            case 0: //English
                language = VoiceEnum.ENGLISH;
                break;
            case 1:
                language = VoiceEnum.ESPANOL;
                break;
            case 2:
                language = VoiceEnum.DEUTSCH;
                break;
            default:
                Debug.Log( "Default Voice selected.  Setting to English" );
                language = VoiceEnum.ENGLISH;
                break;
        }
        return language;
    }

    public VoiceEnum CURRENT_LANGUAGE
    {
        get { return current_language; }
        set 
        {
            //Debug.Log( "setting new language to: " + value );
            current_language = value; 
            foreach ( IObserver<VoiceEnum> voiceObserver in voiceObserverList )
            {
                voiceObserver.OnNext( current_language );
            }
        }
    }

    

    public IDisposable Subscribe( IObserver<VoiceEnum> sub )
    {
        voiceObserverList.Add( sub );

        sub.OnNext( CURRENT_LANGUAGE );

        return new Unsubscriber<VoiceEnum>( voiceObserverList, sub );
    }

    internal class Unsubscriber<VoiceEnum> : IDisposable
    {
        private List<IObserver<VoiceEnum>> voiceObserverList;
        private IObserver<VoiceEnum> voiceObserver;

        internal Unsubscriber( List<IObserver<VoiceEnum>> obList, IObserver<VoiceEnum> voiceOb )
        {
            voiceObserverList = obList;
            voiceObserver = voiceOb;
        }

        public void Dispose()
        {
            voiceObserverList.Remove( voiceObserver );
        }
    }
}
