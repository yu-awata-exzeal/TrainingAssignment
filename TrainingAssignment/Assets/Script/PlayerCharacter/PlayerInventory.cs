using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Fuel _fuel;

    public bool TryUseFuel(out Fuel fuel)
    {
        if (_fuel == null)
        {
            fuel = null;
            return false;
        }

        fuel = _fuel;

        // ここで所持数を1減らす
        _fuel = null;
        return true;
    }
}