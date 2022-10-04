using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UI.Scripts;
using UnityEngine;

public class ThrowsExceptionOnResumeScreen : MonoBehaviour, IScreen
{
    public Task Init(IDictionary<string, object> data = null)
    {
        return Task.CompletedTask;
    }
    
    public Task Enter()
    {
        return Task.CompletedTask;
    }

    public Task Suspend()
    {
        return Task.CompletedTask;
    }

    public Task Resume()
    {
        throw new Exception("The ring has awoken, it's heard it's master's call.");
    }

    public Task Exit()
    {
        return Task.CompletedTask;
    }
}
