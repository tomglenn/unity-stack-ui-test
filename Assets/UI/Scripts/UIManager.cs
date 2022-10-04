using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Scripts;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => instance;

    private static UIManager instance;
    
    [SerializeField] private List<UIKeyValue> screens = new();
    
    private readonly Stack<GameObject> screenStack = new();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Push a new screen to the stack
    /// </summary>
    /// <param name="key">The key for the screen to push</param>
    /// <param name="data">Arbitrary data to pass to the screen </param>
    public async Task PushScreen(string key, IDictionary<string, object> data = null)
    {
        var screenGameObject = GetScreen(key);
        
        if (screenGameObject == null)
        {
            Debug.LogWarningFormat("UI Manager does not contain a screen for key: {0}", key);
            return;
        }

        if (screenStack.TryPeek(out var currentScreen))
        {
            try
            {
                await currentScreen.GetComponent<IScreen>().Suspend();
            }
            catch (Exception ex)
            {
                Debug.LogErrorFormat("Exception occurred when attempting to suspend {0}: {1}", currentScreen.name, ex.Message);
            }
        }

        screenStack.Push(screenGameObject);
        screenGameObject.SetActive(true);
        screenGameObject.transform.SetAsLastSibling();

        try
        {
            await screenGameObject.GetComponent<IScreen>().Init(data);
            await screenGameObject.GetComponent<IScreen>().Enter();
        }
        catch (Exception ex)
        {
            Debug.LogErrorFormat("Exception occurred when pushing {0}; it will now be popped from the stack.\n{1}", screenGameObject.name, ex.Message);
            await PopScreen();
        }
    }

    /// <summary>
    /// Pop the last screen off the stack
    /// </summary>
    public async Task PopScreen()
    {
        if (screenStack.TryPop(out var currentScreen))
        {
            try
            {
                await currentScreen.GetComponent<IScreen>().Exit();
            }
            catch (Exception ex)
            {
                Debug.LogErrorFormat("Exception occurred when exiting {0}; it will now be forcibly deactivated.\n{1}", currentScreen.name, ex.Message);
            }
            
            currentScreen.SetActive(false);
        }

        if (screenStack.TryPeek(out var previousScreen))
        {
            try
            {
                previousScreen.SetActive(true);
                await previousScreen.GetComponent<IScreen>().Resume();
            }
            catch (Exception ex)
            {
                Debug.LogErrorFormat("Exception occurred when resuming {0}; it will now be popped from the stack.\n{1}", previousScreen.name, ex.Message);
                await PopScreen();
            }
        }
    }

    /// <summary>
    /// Pops screens off the stack up to and including the specified screen
    /// </summary>
    /// <param name="key">The key for the screen to pop</param>
    /// <param name="inclusive">Should the specified screen also be popped from the stack?</param>
    public async Task PopScreen(string key, bool inclusive = true)
    {
        var screen = GetScreen(key);
        if (screen == null)
        {
            return;
        }

        if (screenStack.Contains(screen))
        {
            while (screenStack.TryPeek(out var peekedScreen))
            {
                if (!inclusive && peekedScreen == screen)
                {
                    break;
                }

                await PopScreen();

                if (screenStack.TryPeek(out var nextPeekedScreen) && nextPeekedScreen == screen)
                {
                    break;
                }
            }
        }
    }

    private GameObject GetScreen(string key)
    {
        var kvp = screens.FirstOrDefault(s => s.Key == key);
        return kvp?.Value;
    }
}
