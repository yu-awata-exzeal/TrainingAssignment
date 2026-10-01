using Manager;
using UnityEngine;
using UnityEngine.UI;

public class SEButton : Button
{
    [SerializeField]
    private AudioClip _clickSe;

    protected override void Awake()
    {
        base.Awake();

        onClick.AddListener(PlaySe);
    }

    private void PlaySe()
    {
        AudioManager.Instance.PlaySE(_clickSe);
    }
}
