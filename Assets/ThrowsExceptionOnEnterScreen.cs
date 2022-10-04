using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UI.Scripts;
using UnityEngine;

public class ThrowsExceptionOnEnterScreen : MonoBehaviour, IScreen
{
    public Task Init(IDictionary<string, object> data = null)
    {
        return Task.CompletedTask;
    }
    
    public Task Enter()
    {
        throw new Exception("May it be a light to you in dark places, when all other lights go out.");
    }

    public Task Suspend()
    {
        return Task.CompletedTask;
    }

    public Task Resume()
    {
        return Task.CompletedTask;
    }

    public Task Exit()
    {
        return Task.CompletedTask;
    }
}
