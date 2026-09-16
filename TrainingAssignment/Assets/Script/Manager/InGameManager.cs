using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField]
    private StageSettings _currentStageSetting;
    [SerializeField]
    private PlayerCharacter _playerCharactor;
    [SerializeField]
    private BasePoint _basePoint;

    private float _inGameTimer;

    private void Start()
    {

    }

    private void Update()
    {
        _inGameTimer += Time.deltaTime;

        if (_inGameTimer > _currentStageSetting.SurvivalTimeLimit)
        {
            Clear();
        }

        if (_basePoint.CurrentEnelgyContent < 0)
        {
            GameOver();
        }
    }

    private void Clear()
    {

    }

    private void GameOver()
    {

    }
}
