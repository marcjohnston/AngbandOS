// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class LeatherScaleMailSoftArmorItemFactory : SoftArmorItemFactory
{
    private LeatherScaleMailSoftArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenParenthesisSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Leather Scale Mail";

    public override int Ac => 11;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 450;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Leather Scale Mail~";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int ToH => -1;
    public override int Weight => 140;
    public override Item CreateItem() => new LeatherScaleMailSoftArmorItem(SaveGame);
}
