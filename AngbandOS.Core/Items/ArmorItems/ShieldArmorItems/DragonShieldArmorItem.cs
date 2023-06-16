namespace AngbandOS.Core.Items;

[Serializable]
internal class DragonShieldArmorItem : ShieldArmorItem
{
    public DragonShieldArmorItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ShieldDragonShield>()) { }

    /// <summary>
    /// Applies special magic to this dragon shield.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        // Apply the standard armour characteristics, regardless of the power level.
        base.ApplyMagic(level, power, null);

        if (SaveGame.Level != null)
        {
            SaveGame.Level.TreasureRating += 5;
        }
        ApplyDragonscaleResistance();
    }
}