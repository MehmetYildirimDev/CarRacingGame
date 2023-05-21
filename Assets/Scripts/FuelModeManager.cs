using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class FuelModeManager : MonoBehaviour
{

    public static FuelModeManager instance;//Singleton yapiyoz

    [SerializeField] private GameObject Player;
    public TMP_Text CountdownText;
    public float StartingTime = 2f;

    public float startingFuel = 100f; // Baþlangýçta verilecek benzin miktarý
    public float FuelDecreaseSpeed = 1f; // Her saniyede azalacak benzin miktarý
    public float FuelIncreaseAmount = 20f; // Benzini alýndýðýnda artýrýlacak miktar

    public float RepeatRate = 0.5f;
    private float StartingRate = 0.5f;

    public TMP_Text FuelText; // Benzin miktarýný gösteren metin nesnesi

    private float Fuel; // Mevcut benzin miktarý

    public TMP_Text CoinText;
    private int CoinCount;

    [SerializeField] private GameObject PlayOnPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LostPanel;


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        instance = this;
        Time.timeScale = 1f;

        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }

        StartingRate = StartingTime;
    }

    private void Start()
    {
        StartCoroutine(GeriSayimBaslat());

        Fuel = startingFuel;
        CoinCount = 0;

        UpdateCoinUI();
        UpdateFuelUI();

        InvokeRepeating("ReduceFuel", StartingRate, RepeatRate);

    }

    private void UpdateCoinUI()
    {
        CoinText.text = "Coin: " + CoinCount.ToString("F0");
    }

    private void UpdateFuelUI()
    {
        FuelText.text = "Fuel: " + Fuel.ToString("F0");
    }

    private void ReduceFuel()
    {
        Fuel -= FuelDecreaseSpeed;
        UpdateFuelUI();

        if (Fuel <= 0f)
        {
            GameOver(); // Benzin tükendiðinde oyunu bitirme veya baþka bir iþlem yapma

        }
    }

    public void GetFuel()
    {
        Fuel += FuelIncreaseAmount;
        UpdateFuelUI();
    }

    public void GetCoin()
    {
        CoinCount++;
        UpdateCoinUI();
    }

    IEnumerator GeriSayimBaslat()
    {

        Player.GetComponent<CarController>().enabled = false;

        float kalanSure = StartingTime;

        while (kalanSure > 0)
        {
            CountdownText.text = kalanSure.ToString("F0");
            yield return new WaitForSeconds(1f);
            kalanSure--;
        }

        Player.GetComponent<CarController>().enabled = true;

        CountdownText.text = "BASLA!";
        yield return new WaitForSeconds(1f);
        CountdownText.text = " ";
        // Geri sayým tamamlandýktan sonra yapýlacak iþlemleri buraya ekleyebilirsiniz
        Destroy(CountdownText.gameObject);
    }

    private void GameOver()
    {

        SetBestScore();

        Player.GetComponent<CarController>().ForGameFinish();

        CancelInvoke("ReduceFuel");
        LostPanelOn();
    }

    public void GameWin()
    {

        SetBestScore();

        Player.GetComponent<CarController>().ForGameFinish();

        CancelInvoke("ReduceFuel");
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
        WinPanel.transform.Find("BestScoreText(TMP)").gameObject.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("BestScore").ToString();

        WinPanel.transform.Find("NewBestScoreText(TMP)").gameObject.GetComponent<TMP_Text>().text = NewBestScoreText;
    }

    private void LostPanelOn()
    {
        PlayOnPanel.SetActive(false);
        LostPanel.SetActive(true);
        LostPanel.transform.Find("BestScoreText(TMP)").gameObject.GetComponent<TMP_Text>().text = "Best Score " + PlayerPrefs.GetInt("BestScore").ToString();

        LostPanel.transform.Find("NewBestScoreText(TMP)").gameObject.GetComponent<TMP_Text>().text = NewBestScoreText;
    }

    private string NewBestScoreText= " ";

    private void SetBestScore()
    {
        int score = CoinCount;
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            NewBestScoreText = "New Best Score !!!";
        }
    }



    [ContextMenu("ClearBestScore")]
    public void ClearBestScore()
    {
        PlayerPrefs.DeleteKey("BestScore");
    }
}
