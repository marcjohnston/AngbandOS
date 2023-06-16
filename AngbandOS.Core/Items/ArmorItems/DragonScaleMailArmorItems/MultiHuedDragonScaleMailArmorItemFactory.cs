// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class MultiHuedDragonScaleMailArmorItemFactory : DragonScaleMailArmorItemFactory
{
    private MultiHuedDragonScaleMailArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override string? DescribeActivationEffect => "breathe multi-hued (250) every 225+d225 turns";
    public override char Character => '[';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Multi-Hued Dragon Scale Mail";

    public override int Ac => 30;
    public override bool Activate => true;
    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 150000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Multi-Hued Dragon Scale Mail~";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 100;
    public override int[] Locale => new int[] { 100, 0, 0, 0 };
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResPois => true;
    public override int? SubCategory => 6;
    public override int ToA => 10;
    public override int ToH => -2;
    public override int Weight => 200;
    public override Item CreateItem() => new MultiHuedDragonScaleMailArmorItem(SaveGame);
}
