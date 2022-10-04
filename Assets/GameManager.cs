using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string MAIN_MENU_SCREEN = "MAIN_MENU";
    private const string GAME_SCREEN = "GAME";
    private const string SETTINGS_SCREEN = "SETTINGS";
    private const string ALERT_POPUP = "ALERT";
    private const string THROW_ON_ENTER = "THROW_ON_ENTER";
    private const string THROW_ON_SUSPEND = "THROW_ON_SUSPEND";
    private const string THROW_ON_RESUME = "THROW_ON_RESUME";
    private const string THROW_ON_EXIT = "THROW_ON_EXIT";
    
    private async void Start()
    {
        await TestHappyPath();
    }

    private async Task TestHappyPath()
    {
        // Open the main menu screen
        await UIManager.Instance.PushScreen(MAIN_MENU_SCREEN);
        await Task.Delay(500);
        
        // Open the game screen
        await UIManager.Instance.PushScreen(GAME_SCREEN);
        await Task.Delay(500);

        // Open the settings screen
        await UIManager.Instance.PushScreen(SETTINGS_SCREEN);
        await Task.Delay(500);
        
        // Open the alert popup
        await UIManager.Instance.PushScreen(ALERT_POPUP, new Dictionary<string, object> { { "AlertText", "Hello UI" } });
        await Task.Delay(500);
        
        // Return to the main menu screen
        await UIManager.Instance.PopScreen(MAIN_MENU_SCREEN, false);
        await Task.Delay(500);
        
        Debug.Log("Test complete");
    }
    
    private async Task TestThrowOnEnter()
    {
        // Open the main menu screen
        await UIManager.Instance.PushScreen(MAIN_MENU_SCREEN);
        await Task.Delay(500);
        
        // Open the game screen
        await UIManager.Instance.PushScreen(GAME_SCREEN);
        await Task.Delay(500);

        // Open the throw on enter screen
        await UIManager.Instance.PushScreen(THROW_ON_ENTER);
        await Task.Delay(500);
        
        // Open the alert popup
        await UIManager.Instance.PushScreen(ALERT_POPUP, new Dictionary<string, object> { { "AlertText", "Hello UI" } });
        await Task.Delay(500);
        
        // Return to the main menu screen
        await UIManager.Instance.PopScreen(MAIN_MENU_SCREEN, false);
        await Task.Delay(500);
        
        Debug.Log("Test complete");
    }
    
    private async Task TestThrowOnSuspend()
    {
        // Open the main menu screen
        await UIManager.Instance.PushScreen(MAIN_MENU_SCREEN);
        await Task.Delay(500);
        
        // Open the game screen
        await UIManager.Instance.PushScreen(GAME_SCREEN);
        await Task.Delay(500);

        // Open the throw on suspend screen
        await UIManager.Instance.PushScreen(THROW_ON_SUSPEND);
        await Task.Delay(500);
        
        // Open the alert popup
        await UIManager.Instance.PushScreen(ALERT_POPUP, new Dictionary<string, object> { { "AlertText", "Hello UI" } });
        await Task.Delay(500);
        
        // Return to the main menu screen
        await UIManager.Instance.PopScreen(MAIN_MENU_SCREEN, false);
        await Task.Delay(500);
        
        Debug.Log("Test complete");
    }
    
    private async Task TestThrowOnResume()
    {
        // Open the main menu screen
        await UIManager.Instance.PushScreen(MAIN_MENU_SCREEN);
        await Task.Delay(500);
        
        // Open the game screen
        await UIManager.Instance.PushScreen(GAME_SCREEN);
        await Task.Delay(500);

        // Open the throw on resume screen
        await UIManager.Instance.PushScreen(THROW_ON_RESUME);
        await Task.Delay(500);
        
        // Open the alert popup
        await UIManager.Instance.PushScreen(ALERT_POPUP, new Dictionary<string, object> { { "AlertText", "Hello UI" } });
        await Task.Delay(500);
        
        // Return to the main menu screen
        await UIManager.Instance.PopScreen(MAIN_MENU_SCREEN, false);
        await Task.Delay(500);
        
        Debug.Log("Test complete");
    }
    
    private async Task TestThrowOnExit()
    {
        // Open the main menu screen
        await UIManager.Instance.PushScreen(MAIN_MENU_SCREEN);
        await Task.Delay(500);
        
        // Open the game screen
        await UIManager.Instance.PushScreen(GAME_SCREEN);
        await Task.Delay(500);

        // Open the throw on exit screen
        await UIManager.Instance.PushScreen(THROW_ON_EXIT);
        await Task.Delay(500);
        
        // Open the alert popup
        await UIManager.Instance.PushScreen(ALERT_POPUP, new Dictionary<string, object> { { "AlertText", "Hello UI" } });
        await Task.Delay(500);
        
        // Return to the main menu screen
        await UIManager.Instance.PopScreen(MAIN_MENU_SCREEN, false);
        await Task.Delay(500);
        
        Debug.Log("Test complete");
    }
}
