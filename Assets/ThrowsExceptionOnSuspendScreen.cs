using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UI.Scripts;
using UnityEngine;

public class ThrowsExceptionOnSuspendScreen : MonoBehaviour, IScreen
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
        throw new Exception("Faithless is he that says farewell when the road darkens.");
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
