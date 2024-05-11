using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Riferimento al componente Button del button Play
    public Button playButton;

    private void Start()
    {
        // Ascolta il click sul button Play
        playButton.onClick.AddListener(PlayGame);
    }

    // Funzione chiamata quando si clicca il button Play
    private void PlayGame()
    {
        // Carica la scena FirstLevel
        SceneManager.LoadScene("FirstLevel");
    }
}




