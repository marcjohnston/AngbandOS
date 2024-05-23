// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class NewLifePotionItemFactory : PotionItemFactory
{
    private NewLifePotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "New Life";

    public override int Cost => 750000;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "New Life";
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 20),
        (100, 10),
        (120, 5)
    };
    public override int InitialNutritionalValue => 100;
    public override int Weight => 4;
    public override bool Quaff()
    {
        // New life rerolls your health, cures all mutations, and restores you to your birth race
        Game.RunScript(nameof(RerollHitPointsScript));
        if (Game.HasMutations)
        {
            Game.MsgPrint("You are cured of all mutations.");
            Game.LoseAllMutations();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            Game.HandleStuff();
        }
        if (!(Game.Race.GetType() == Game.RaceAtBirth.GetType()))
        {
            var oldRaceName = Game.RaceAtBirth.Title;
            Game.MsgPrint($"You feel more {oldRaceName} again.");
            Game.ChangeRace(Game.RaceAtBirth);
            Game.MainForm.RefreshMapLocation(Game.MapY.IntValue, Game.MapX.IntValue);
        }
        return true;
    }
}
