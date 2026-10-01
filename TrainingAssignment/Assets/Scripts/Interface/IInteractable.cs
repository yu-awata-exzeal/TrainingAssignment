using Manager;

public enum InteractType
{
    ButtonInput,
    TriggerEnter,
    TriggerStay,
}

/// <summary>
/// プレイヤーからのインタラクト対象インターフェース
/// </summary>
public interface IInteractable
{
    void Interact(InteractionContext context);
}
