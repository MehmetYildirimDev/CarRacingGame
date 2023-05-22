using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarSelectionManager : MonoBehaviour
{
    public Transform Cilyinder;
    public float RotateSpeed;

    public List<Mesh> meshes = new List<Mesh>();

    public GameObject PlayerBody;

    [SerializeField] int index;

    private void Start()
    {
        

        if (!PlayerPrefs.HasKey("SelectCarColor"))
        {
            PlayerPrefs.SetInt("SelectCarColor", 0);
        }
        index = PlayerPrefs.GetInt("SelectCarColor");
        ChangeMesh(index);
    }

    private void FixedUpdate()
    {
        Cilyinder.transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
    }

    public void RightButton_OnClick()
    {
        if (index >= (meshes.Count - 1))
        {
            index = 0;
            ChangeMesh(index);
            return;
        }
        index++;
        ChangeMesh(index);
    }

    public void LeftButton_OnClick()
    {
        if (index <= 0)
        {
            index = meshes.Count - 1;
            ChangeMesh(index);
            return;
        }
        index--;
        ChangeMesh(index);
    }

    private void ChangeMesh(int index)
    {
        PlayerBody.GetComponent<MeshFilter>().mesh = meshes[index];
    }

    public void BackButton_OnClick()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void onClick_RaceMode()
    {
        SceneManager.LoadScene("RaceModeScene");
        PlayerPrefs.SetInt("SelectCarColor", index);
    }

    public void onClick_FuelMode()
    {
        SceneManager.LoadScene("FuelModeScene");
        PlayerPrefs.SetInt("SelectCarColor", index);
    }
}
