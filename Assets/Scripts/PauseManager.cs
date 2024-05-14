using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public Canvas pauseCanvas;
    public Canvas menuCanvas;

    public void ShowPauseCanvas()
    {
        Time.timeScale = 0f;
        menuCanvas.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(true);
    }

    public void HidePauseCanvas()
    {
        Time.timeScale = 1f;
        menuCanvas.gameObject.SetActive(true);
        pauseCanvas.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowHintText()
    {
        menuCanvas.transform.Find("Hint").gameObject.SetActive(true);
    }

    public void HideHintText()
    {
        menuCanvas.transform.Find("Hint").gameObject.SetActive(false);
    }

    public void ShowVictoryText()
    {
        menuCanvas.transform.Find("Victory").gameObject.SetActive(true);
    }

}
