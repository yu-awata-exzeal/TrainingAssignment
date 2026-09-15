using UnityEngine;

public class BasePoint : MonoBehaviour, IInteractable
{
    /// <summary>
    /// 現在のエネルギー量
    /// </summary>
    private int _currntEnergyContent = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Interact(InteractionContext context)
    {

        if (!context.Inventory.TryUseFuel(
               out var item))
        {
            return;
        }

        //回復
        _currntEnergyContent += item.Content;
    }
}
