using Manager;

public enum InteractType
{
    ButtonInput,
    OnTriggerEnter,
    OnTriggerStay,
}

/// <summary>
/// プレイヤーからのインタラクト対象インターフェース
/// </summary>
public interface IInteractable
{
    void Interact(InteractionContext context);
}
