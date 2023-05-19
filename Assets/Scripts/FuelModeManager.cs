using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FuelModeManager : MonoBehaviour
{

    public static FuelModeManager instance;//Singleton yapiyoz

    GameObject Player;
    public TMP_Text CountdownText;
    public float StartingTime = 2f;

    public float startingFuel = 100f; // Ba�lang��ta verilecek benzin miktar�
    public float FuelDecreaseSpeed = 1f; // Her saniyede azalacak benzin miktar�
    public float FuelIncreaseAmount = 20f; // Benzini al�nd���nda art�r�lacak miktar

    public float RepeatRate = 0.5f;
    private float StartingRate = 0.5f;

    public TMP_Text FuelText; // Benzin miktar�n� g�steren metin nesnesi

    private float Fuel; // Mevcut benzin miktar�

    public TMP_Text CoinText;
    private int CoinCount;



    private void Awake()
    {

        instance = this;
        Player = GameObject.Find("PlayerCar");

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
            GameOver(); // Benzin t�kendi�inde oyunu bitirme veya ba�ka bir i�lem yapma
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
        // Geri say�m tamamland�ktan sonra yap�lacak i�lemleri buraya ekleyebilirsiniz
    }

    private void GameOver()
    {
        // Oyunu bitirme veya ba�ka bir i�lem yapma
        //surtunme vererek durmasini sagliyoruz
        Player.GetComponent<CarController>().carRb.drag = 1f;

    }


}
