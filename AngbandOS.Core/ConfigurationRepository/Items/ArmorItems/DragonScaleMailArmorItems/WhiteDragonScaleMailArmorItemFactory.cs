// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

using AngbandOS.Core.Items;

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class WhiteDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory
{
    private WhiteDragonScaleMailArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override string? DescribeActivationEffect => "breathe frost (110) every 450+d450 turns";
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBraceSymbol>();
    public override string Name => "White Dragon Scale Mail";

    public override int Ac => 30;
    public override bool Activate => true;
    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 40000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "White Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override bool ResCold => true;
    public override int ToA => 10;
    public override int ToH => -2;
    public override int Weight => 200;
    public override Item CreateItem() => new WhiteDragonScaleMailArmorItem(SaveGame);
}