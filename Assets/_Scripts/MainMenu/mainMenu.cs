using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("Lyubo");
        Debug.Log("Play Game");
    }
}
