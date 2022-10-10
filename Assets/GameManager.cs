using UnityEngine.UI;
using Unity;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private AudioSource _audio;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    public float _soundVolume;
    

    public delegate void OnVolumeChanged(float value);
    public static  OnVolumeChanged onVolumeChanged;

    public delegate void OnResetGame();
    public static OnResetGame onResetGame;

    private void OnEnable()
    {
        BlockMover.onWin += Win;
        BlockMover.onLose += Lose;
    }

    private void OnDisable()
    {
        BlockMover.onWin -= Win;
        BlockMover.onLose -= Lose;
    }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {     
        _soundVolume = DataSaveLoad.LoadData();
        ChangeSoundVolume(_soundVolume);
    }

    private void OnApplicationQuit()
    {
        DataSaveLoad.SaveData(_soundVolume);
    }

    IEnumerator WinPanelOpen()
    {
        yield return new WaitForSeconds(1f);
        _winPanel.SetActive(true);
    }

    public void ResetGame()
    {
        onResetGame();
    }

    public void ChangeSoundVolume(float value)
    {
        _soundVolume = value;
        _audio.volume = _soundVolume;
        onVolumeChanged(value);
    }

    public void ChangeVolumeUIOnPanelOpen()
    {
        ChangeSoundVolume(_soundVolume);
    }

    public void Win()
    {
        StartCoroutine(WinPanelOpen());
    }

    private void Lose()
    {
        _losePanel.SetActive(true);
    }

 
}
