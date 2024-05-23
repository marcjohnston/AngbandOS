// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LoseMemoriesPotionItemFactory : PotionItemFactory
{
    private LoseMemoriesPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Lose Memories";

    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "Lose Memories";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Lose Memories reduces your experience
        if (!Game.HasHoldLife && Game.ExperiencePoints.IntValue > 0)
        {
            Game.MsgPrint("You feel your memories fade.");
            Game.LoseExperience(Game.ExperiencePoints.IntValue / 4);
            return true;
        }
        return false;
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
}
