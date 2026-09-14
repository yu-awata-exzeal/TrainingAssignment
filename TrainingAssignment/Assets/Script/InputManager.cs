using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionContext
{
    public PlayerInventory Inventory { get; init; }

}

/// <summary>
/// ゲーム内の入力判定を管理するクラス
/// </summary>
public class InputManager : MonoBehaviour
{

    public InputManager()
    {
        foreach (var action in InputSystem.actions)
        {
            action.performed += (context) => { };
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
