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

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Lose Memories";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Lose Memories";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Lose Memories reduces your experience
        if (!Game.HasHoldLife && Game.ExperiencePoints.Value > 0)
        {
            Game.MsgPrint("You feel your memories fade.");
            Game.LoseExperience(Game.ExperiencePoints.Value / 4);
            return true;
        }
        return false;
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
