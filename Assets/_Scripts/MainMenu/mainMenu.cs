using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Lyubo");
    }
    
    public void quitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
               SceneManager.LoadScene("Credits");
    }
    public void BackToMenu()
    {
                      SceneManager.LoadScene("mainMenu");
    }


}
