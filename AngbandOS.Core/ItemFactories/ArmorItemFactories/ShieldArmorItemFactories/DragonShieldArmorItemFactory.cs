// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DragonShieldArmorItemFactory : ShieldArmorItemFactory
{
    private DragonShieldArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(OpenBraceSymbol));
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Dragon Shield";


    /// <summary>
    /// Applies special magic to this dragon shield.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        // Apply the standard armor characteristics, regardless of the power level.
        base.ApplyMagic(item, level, power, null);

        Game.TreasureRating += 5;
        ApplyDragonscaleResistance(item);
    }

    public override int Ac => 8;
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 10000;
    public override int Dd => 1;
    public override int Ds => 3;
    public override string FriendlyName => "& Dragon Shield~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 70;
    public override int[] Locale => new int[] { 80, 0, 0, 0 };
    public override int ToA => 10;
    public override int Weight => 100;
    public override Item CreateItem() => new Item(Game, this);
}