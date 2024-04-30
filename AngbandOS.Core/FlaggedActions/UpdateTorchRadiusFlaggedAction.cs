// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateTorchRadiusFlaggedAction : FlaggedAction
{
    private int OldLightLevel;
    private UpdateTorchRadiusFlaggedAction(Game game) : base(game) { }
    /// <summary>
    /// Compute the level of light.  The player may be wielding multiple sources of light.
    /// </summary>
    protected override void Execute()
    {
        Game.LightLevel = 0;
        foreach (BaseInventorySlot inventorySlot in Game.SingletonRepository.Get<BaseInventorySlot>().Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(i);
                if (oPtr != null)
                {
                    Game.LightLevel += oPtr.Factory.CalculateTorch(oPtr);
                }
            }
        }
        if (Game.LightLevel > 5)
        {
            Game.LightLevel = 5;
        }
        if (Game.LightLevel == 0 && Game.HasGlow)
        {
            Game.LightLevel = 1;
        }
        if (OldLightLevel != Game.LightLevel)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
            OldLightLevel = Game.LightLevel;
        }
    }
}