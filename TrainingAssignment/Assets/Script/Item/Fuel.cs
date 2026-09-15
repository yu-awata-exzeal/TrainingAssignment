using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField]
    private StageSettings _currentStageSetting;

    public int Content => _currentStageSetting.FuelContent;
}