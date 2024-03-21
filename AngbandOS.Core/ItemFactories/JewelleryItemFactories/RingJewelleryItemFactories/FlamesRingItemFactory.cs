// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FlamesRingItemFactory : RingItemFactory, IItemsCanBeActivated
{
    private FlamesRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public void ActivateItem(Item item)
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, 50, 2);
        SaveGame.FireResistanceTimer.AddTimer(SaveGame.DieRoll(20) + 20);
        item.RechargeTimeLeft = SaveGame.RandomLessThan(50) + 50;
    }

    public override string? DescribeActivationEffect => "ball of fire and resist fire";
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Flames";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.BonusArmorClass = 5 + SaveGame.DieRoll(5) + item.GetBonusValue(10, level);
    }
    public override bool Activate => true;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 3000;
    public override string FriendlyName => "Flames";
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override bool ResFire => true;
    public override int ToA => 15;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(SaveGame, this);
}
