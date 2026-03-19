using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
   
    public void LoadInstructionScene()
    {
        SceneManager.LoadSceneAsync("InstructionScene", LoadSceneMode.Single);
    }
}