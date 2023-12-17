using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context 
{
    public static Context _instance;

    public static Context Instance => _instance ??= new Context();

    public ISaveSystem SaveSystem { get; private set; }

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
    }
}
