using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResoluitonController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filterResolutions;

    private int currentResolutionIndex = 0;

    private void Start()
    {
        resolutions = Screen.resolutions;
        filterResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();

        for (int i = 0; i < resolutions.Length; i++)
        {
            filterResolutions.Add(resolutions[i]);
        }

        List<string> options = new List<string>();

        for (int i = 0; i < filterResolutions.Count; i++)
        {
            string resolutionOption = filterResolutions[i].width + "x" + filterResolutions[i].height;
            options.Add(resolutionOption);

            if (filterResolutions[i].width == Screen.width && filterResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filterResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

}
