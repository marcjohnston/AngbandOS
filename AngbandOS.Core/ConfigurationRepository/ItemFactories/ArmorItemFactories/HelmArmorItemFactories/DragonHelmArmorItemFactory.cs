// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DragonHelmArmorItemFactory : HelmArmorItemFactory
{
    private DragonHelmArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Dragon Helm";

    /// <summary>
    /// Applies special magic to this dragon helm.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        // Apply the standard armor characteristics, regardless of the power.
        base.ApplyMagic(item, level, power, null);

        SaveGame.TreasureRating += 5;
        ApplyDragonscaleResistance(item);
    }
    public override int Ac => 8;
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 10000;
    public override int Dd => 1;
    public override int Ds => 3;
    public override string FriendlyName => "& Dragon Helm~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 45;
    public override int[] Locale => new int[] { 80, 0, 0, 0 };
    public override int ToA => 10;
    public override int Weight => 50;
    public override Item CreateItem() => new Item(SaveGame, this);
}