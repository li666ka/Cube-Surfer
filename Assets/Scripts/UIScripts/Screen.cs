using UnityEngine;

public class Screen : MonoBehaviour
{
    public void Show()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void Show(bool hasStopGame = true)
    {
        if (hasStopGame)
        {
            Time.timeScale = 0f;
        }
        gameObject.SetActive(true);
    }

    public void Hide(bool hasStartGame = true)
    {
        if (hasStartGame)
        {
            Time.timeScale = 1f;
        }
        gameObject.SetActive(false);
    }
}
