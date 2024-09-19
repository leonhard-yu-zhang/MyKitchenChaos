using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        TestingEvents testingEvents = GetComponent<TestingEvents>();
        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;
    }

    private void TestingEvents_OnSpacePressed(object sender, TestingEvents.OnSpacePressedEventArgs e)
    {
        Debug.Log("Q!" + e.keyCount);
        TestingEvents testingEvents = GetComponent<TestingEvents>();
        testingEvents.OnSpacePressed -= TestingEvents_OnSpacePressed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
