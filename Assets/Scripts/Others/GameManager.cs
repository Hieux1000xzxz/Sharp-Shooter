using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text enemiesLeftText;
    [SerializeField] GameObject gameWinContainer;
    [SerializeField] GameObject inGameUI;
    [SerializeField] StarterAssetsInputs starterAssetsInputs;

    int enemiesLeft = 0;
    public void AdjustEnemiesLeft(int amount)
    {
        enemiesLeft += amount;
        enemiesLeftText.text = $"Enemies Left: {enemiesLeft}";
        if (enemiesLeft == 0)
        {
            gameWinContainer.SetActive(true);
            starterAssetsInputs.SetCursorState(false);
            inGameUI.SetActive(false);
        }
    }
    public void RestartLevelButton()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}
