using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlNext : MonoBehaviour
{
    [SerializeField] GameObject startMenu, gameMenu;
    private void Start()
    {
        if (PlayerPrefs.HasKey("InGame"))
        {
            int inGame = PlayerPrefs.GetInt("InGame");
            if(inGame > 0)
            {
                startMenu.SetActive(false);
                gameMenu.SetActive(true);
            }
        }
    }
    public void LoadLevelInt(int levelI = 0)
    {
        PlayerPrefs.SetInt("InGame", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(levelI);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("InGame", 0);
        PlayerPrefs.Save();
    }
}
