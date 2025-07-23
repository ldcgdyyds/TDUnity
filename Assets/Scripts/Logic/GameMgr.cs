using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public MainPanel mainPanel;
    public SelectPanel selectPanel;
    public CombatPanel combatPanel;
    public ShopPanel shopPanel;
    private void Start()
    {
        mainPanel.btnStart.onClick.AddListener(StartGame);
        mainPanel.btnQuit.onClick.AddListener(QuitGame);
        selectPanel.btnBack.onClick.AddListener(BackToMain);
    }
    private void StartGame()
    {
        mainPanel.gameObject.SetActive(false);
        selectPanel.gameObject.SetActive(true);
    }
    private void BackToMain()
    {
        selectPanel.gameObject.SetActive(false);
        mainPanel.gameObject.SetActive(true);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
