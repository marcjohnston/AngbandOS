// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LeadFilledMaceHaftedWeaponItemFactory : HaftedWeaponItemFactory
{
    private LeadFilledMaceHaftedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Lead-Filled Mace";

    public override int Cost => 502;
    public override int Dd => 3;
    public override int Ds => 4;
    public override string FriendlyName => "& Lead-Filled Mace~";
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 180;
    public override Item CreateItem() => new Item(Game, this);
}
