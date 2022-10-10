using UnityEngine;
using UnityEngine.UI;

public class BlockDisapier : MonoBehaviour
{
    private Animator _anim;
    private Image _img;

    private void OnEnable()
    {
        BlockMover.onWin += Disapier;
        GameManager.onResetGame += Reset;
        _anim = GetComponent<Animator>();
        _img = GetComponent<Image>();
    }

    private void OnDisable()
    {
        BlockMover.onWin -= Disapier;
        GameManager.onResetGame -= Reset;
    }

    private void Disapier()
    {
        _anim.enabled = true;
    }

    public void Reset()
    {
        _anim.enabled = false;
        _img.fillAmount = 1f;
    }
}
