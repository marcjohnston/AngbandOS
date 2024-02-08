// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class FilbertTheHungryShopkeeper : Shopkeeper
{
    private FilbertTheHungryShopkeeper(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Name => "Filbert the Hungry";
    public override int MaxCost =>  750;
    public override int MinInflate =>  107;
    protected override string? RaceName => nameof(VampireRace);
}