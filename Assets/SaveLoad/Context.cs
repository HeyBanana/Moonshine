using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IAudioSystem;

public class Context
{
    public static Context _instance;
    public const string GameLaunchModKey = "GameLaunch";

    public static Context Instance => _instance ??= new Context();

    public ISaveSystem SaveSystem { get; private set; }

    public IAudioSystem AudioSystem { get; private set; }

    // public IAppSystem AppSystem { get; private set; } 


    private Context()
    {
        _instance = this;
        Initialize();
    }
    //ToDo call this method on game entry point
    private void Initialize()
    {
        SaveSystem = new SaveSystem();
        Instance.AudioSystem = new AudioSystem();
    }
    
    

}
