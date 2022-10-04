using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UI.Scripts;
using UnityEngine;

public class ThrowsExceptionOnExitScreen : MonoBehaviour, IScreen
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
        return Task.CompletedTask;
    }

    public Task Exit()
    {
        throw new Exception("In this hour, I do not believe that any darkness will endure.");
    }
}
