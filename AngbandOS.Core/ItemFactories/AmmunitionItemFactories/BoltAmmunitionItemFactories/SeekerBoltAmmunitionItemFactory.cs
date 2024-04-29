// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SeekerBoltAmmunitionItemFactory : BoltAmmunitionItemFactory
{
    private SeekerBoltAmmunitionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(OpenBracketSymbol));
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Seeker Bolt";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 25;
    public override int Dd => 4;
    public override int Ds => 5;
    public override string FriendlyName => "& Seeker Bolt~";
    public override int LevelNormallyFound => 65;
    public override int[] Locale => new int[] { 65, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 3;
    public override Item CreateItem() => new Item(Game, this);
}
