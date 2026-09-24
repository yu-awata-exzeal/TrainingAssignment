using Manager;

public enum InteractType
{
    ButtonInput,
    OnTrigger,
}

/// <summary>
/// プレイヤーからのインタラクト対象インターフェース
/// </summary>
public interface IInteractable
{
    InteractType Type { get; }

    void Interact(InteractionContext context);
}
