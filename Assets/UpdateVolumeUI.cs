using UnityEngine.UI;
using UnityEngine;

public class UpdateVolumeUI : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    private Text _volumeText;


    private void OnEnable()
    {
        _volumeText = this.GetComponent<Text>();
        GameManager.onVolumeChanged += ChangeVolumeText;
    }
    private void OnDisable()
    {
        GameManager.onVolumeChanged -= ChangeVolumeText;
    }

    private void ChangeVolumeText(float value)
    {
        _volumeText.text = $"{(int)(value * 100)}%";
        _volumeSlider.value = value;
    }
}
