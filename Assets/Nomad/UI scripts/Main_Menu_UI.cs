using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Main_Menu_UI : MonoBehaviour
{
    [Header ("Level loading")]
    public string LevelToLoad;
    public string MainMenuScene;
    [SerializeField] Transform Continue_Popup;

    [Header("Audio")]
    [SerializeField] TMP_Text volume_value;
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume;

    [Header("Graphics")]
    [SerializeField] TMP_Text brightness_value;
    [SerializeField] Slider brightnessSlider;
    [SerializeField] float defaultBrightness =1;
    [SerializeField] Toggle fullscreenToggle;

    public TMP_Dropdown dropdown;
    private Resolution[] resolutions;

    private bool isFullscreen;
    private float brightness;

    private void Start()
    {
        resolutions = Screen.resolutions;
        dropdown.ClearOptions();

        List<string> options = new List<string>();
        int index_cureent_resolution = 0;

        for(int i = 0; i < resolutions.Length; i++) { 
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].height == Screen.height && resolutions[i].width == Screen.width) index_cureent_resolution = i;
        }

        dropdown.AddOptions(options);
        dropdown.value = index_cureent_resolution;
        dropdown.RefreshShownValue();
    }
    public void StartNewGame()
    {
        PlayerPrefs.SetInt("isLoadingLevel", 0);
        SceneManager.LoadScene(LevelToLoad);
    }
    public void LoadGame()
    {
        string path = Path.Combine(Application.persistentDataPath, "playerData.json");

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);

            PlayerData data = JsonUtility.FromJson<PlayerData>(jsonData);
            SceneManager.LoadScene(data.scene);
            PlayerPrefs.SetInt("isLoadingLevel", 1);

            Debug.Log("Level loaded!");
        }
        else
        {
            gameObject.SetActive(false);
            Continue_Popup.gameObject.SetActive(true);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }
    public void Continue()
    {
        //Apply logic here!
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void setVolume(float volume)
    {
        AudioListener.volume = volume;
        volume_value.text = volume.ToString("0.0");
    }

    public void applyVolume()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        Debug.Log("Volume applied!");
    }

    public void setBrightness(float _brightness)
    {
        brightness = _brightness;
        brightness_value.text = brightness.ToString("0.0");
    }

    public void setFullscreen(bool _fullscreen)
    {
        isFullscreen = _fullscreen;
    }

    public void applyGraphics()
    {
        PlayerPrefs.SetFloat("masterBrightness", brightness);
        PlayerPrefs.SetInt("masterFullscreen", (isFullscreen ? 1 : 0));
        Screen.fullScreen = isFullscreen;   
    }

    public void setResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
    }

    public void resetValues(string MenuType)
    {
        if(MenuType == "Audio") {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volume_value.text = defaultVolume.ToString("0.0");
            applyVolume();
        }
        if (MenuType == "Graphics")
        {
            brightnessSlider.value = defaultBrightness;
            brightness_value.text = defaultBrightness.ToString("0.0");
            fullscreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution res = Screen.currentResolution;
            Screen.SetResolution(res.width,res.height,Screen.fullScreen);
            dropdown.value = resolutions.Length;

            applyGraphics();
        }
    }
}
