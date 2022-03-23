using System;
using System.Collections.Generic;
using UnityEngine;

public class Action : ITask
{
    private Func<bool> actionFunction;

    public Action(Func<bool> actionFunction)
    {
        this.actionFunction = actionFunction;

    }
    //public void 
    public bool Execute()
    {
        actionFunction();
        return true;
    }
}
