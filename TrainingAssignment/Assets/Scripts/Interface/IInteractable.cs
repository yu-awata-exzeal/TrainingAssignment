using Manager;

public enum InteractType
{
    ButtonInput,
    OnTriggerEnter,
    OnTriggerStay,
    Raycast,
}

/// <summary>
/// プレイヤーからのインタラクト対象インターフェース
/// </summary>
public interface IInteractable
{
    InteractType Type { get; }

    void Interact(InteractionContext context);
}
