// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SteelHelmArmorItemFactory : HelmArmorItemFactory
{
    private SteelHelmArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Steel Helm";

    public override int Ac => 6;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 200;
    public override int Dd => 1;
    public override int Ds => 3;
    public override string FriendlyName => "& Steel Helm~";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int Weight => 60;
    public override Item CreateItem() => new SteelHelmArmorItem(SaveGame);
}