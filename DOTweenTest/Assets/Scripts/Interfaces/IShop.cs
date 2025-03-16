using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShop
{
    void InitShop();
    void BuyUpgrade(UpgradeData upgrade);
    void RemoveItemToShop(UpgradeData upgrade);
    void ApplyUpgrade(UpgradeData upgrade);
}
