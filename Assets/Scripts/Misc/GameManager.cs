using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject youWinText;

    int enemiesLeft = 0;

    const string ENEMIES_LEFT_STRING = "Enemies Left: ";

    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;

        if (enemiesLeftText) // ✅ 파괴/미할당 방지
            enemiesLeftText.text = ENEMIES_LEFT_STRING + enemiesLeft.ToString();

        if (enemiesLeft <= 0)
        {
            if (youWinText) // ✅ 파괴/미할당 방지
                youWinText.SetActive(true);
        }
    }
    
    public void RestartLevelButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);

    }

    public void QuitButton()
    {
        Debug.LogWarning("Does not work in the Unity Editor!");
        Application.Quit();
    }
  
}
