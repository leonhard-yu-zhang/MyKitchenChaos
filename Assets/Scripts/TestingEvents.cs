using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEvents : MonoBehaviour
{
    // adelegatewith2fields
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;

    public class OnSpacePressedEventArgs: EventArgs
    {
        public int keyCount;
    }

    private int keyCount;
    private void Start()
    {
       // OnSpacePressed += Testing_OnSpacePressed;
    }
/*    private void Testing_OnSpacePressed(object sender, EventArgs e)
    {
        Debug.Log("Space!");
    }*/
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            /*            if (OneSpacePressed != null)
                        {
                            OnSpacePressed(this, EventArgs.Empty);
                        }*/
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { keyCount = keyCount});
        }
    }
}
