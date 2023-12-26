using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FSMState_UI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _fsmName;
    [SerializeField] TextMeshProUGUI _fsmState;

    //public IFSMNaming fSMNaming;
    private AI testingEvents;


    private void Start()
    {
        testingEvents = GetComponent<AI>();
        _fsmName.text = testingEvents.NameFSM;
        _fsmState.text = "State";


        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;

        testingEvents.OnCurrentState += ChangeState;

    }

    private void ChangeState(State state)
    {
        _fsmState.text = state.ToString();
    }

    private void TestingEvents_OnSpacePressed(object sender, EventArgs e)
    {
        Debug.Log("Q-Key");

        _fsmState.text = "Q-Key";
    }

}
