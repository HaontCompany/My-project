using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SoundChange : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Text soundValueT;
    [SerializeField] Slider sliderV;
    private float volumef;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumef = PlayerPrefs.GetFloat("Volume");
            audioMixer.SetFloat("Volume", volumef);

            sliderV.value = Mathf.RoundToInt(volumef);
            soundValueT.text = "ÇÂÓÊ: " + Mathf.RoundToInt(75 + (volumef * 2.5f)) + "%";

            audioMixer.SetFloat("Volume", volumef);
            Debug.Log(volumef);
        }
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        soundValueT.text = "ÇÂÓÊ: " + Mathf.RoundToInt(75 + (volume * 2.5f)) + "%";
    }
    public void SaveVolume()
    {
        audioMixer.GetFloat("Volume", out volumef);
        PlayerPrefs.SetFloat("Volume", volumef);
        PlayerPrefs.Save();
    }
}
