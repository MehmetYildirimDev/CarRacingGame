using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RaceModeGameManager : MonoBehaviour
{

    public static RaceModeGameManager instance;//Singleton yapiyoz 

    [SerializeField] private GameObject Player;

    public TMP_Text CountdownText;
    public TMP_Text CarSpeedText;

    public float StartingTime = 3f;

    [SerializeField] private GameObject PlayOnPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LostPanel;

    public List<GameObject> arabalar = new List<GameObject>();
    public List<TMP_Text> RankingListText = new List<TMP_Text>();

    public int MaxTourCount;

    public float StartingPointcooldownTime = 10f;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        StartCoroutine(StartCountDown());

        InvokeRepeating("SiralamaGuncelle", StartingTime, 1f);
    }


    IEnumerator StartCountDown()
    {

        Player.GetComponent<CarController>().enabled = false;

        float remainingTime = StartingTime;

        while (remainingTime > 0)
        {
            CountdownText.text = remainingTime.ToString("F0");
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }

        Player.GetComponent<CarController>().enabled = true;

        CountdownText.text = "BASLA!!!";
        yield return new WaitForSeconds(1f);
        CountdownText.text = " ";
        // Geri sayým tamamlandýktan sonra yapýlacak iþlemleri buraya ekleyebilirsiniz
        Destroy(CountdownText.gameObject);
    }


    private void Update()
    {
        UpdateCarSpeedUI();
    }

    private void UpdateCarSpeedUI()
    {
        CarSpeedText.text = (Player.GetComponent<Rigidbody>().velocity.magnitude * 4).ToString("F0");
    }

    private void GameOver()
    {
        Player.GetComponent<CarController>().ForGameFinish();

        LostPanelOn();
    }

    public void GameWin()
    {

        Player.GetComponent<CarController>().ForGameFinish();

        WinPanelOn();
    }

    public void Pause_Onclick()
    {
        PlayOnPanel.SetActive(false);
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void Resume_Onclick()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        PlayOnPanel.SetActive(true);
    }

    public void MainMenu_Onclick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart_Onclick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void WinPanelOn()
    {
        PlayOnPanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    private void LostPanelOn()
    {
        PlayOnPanel.SetActive(false);
        LostPanel.SetActive(true);
    }




    private void SiralamaGuncelle()
    {
        arabalar.Sort((a, b) => b.GetComponent<RaceInfo>().AlinanYol.CompareTo(a.GetComponent<RaceInfo>().AlinanYol));

        for (int i = 0; i < arabalar.Count; i++)
        {

            RankingListText[i].text = (i + 1) + ". " + arabalar[i].GetComponent<RaceInfo>().LabelName;
            RankingListText[i].color = arabalar[i].GetComponent<RaceInfo>().TextColor;
        }

    }

}
