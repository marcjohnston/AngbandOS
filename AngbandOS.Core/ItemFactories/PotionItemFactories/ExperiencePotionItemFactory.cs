// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ExperiencePotionItemFactory : PotionItemFactory
{
    private ExperiencePotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Experience";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 25000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Experience";
    public override int LevelNormallyFound => 65;
    public override int[] Locale => new int[] { 65, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Experience increases your experience points by 50%, with a minimum of +10 and
        // maximuum of +10,000
        if (Game.ExperiencePoints.IntValue < Constants.PyMaxExp)
        {
            int ee = (Game.ExperiencePoints.IntValue / 2) + 10;
            if (ee > 100000)
            {
                ee = 100000;
            }
            Game.MsgPrint("You feel more experienced.");
            Game.GainExperience(ee);
            return true;
        }
        return false;
    }
    public override Item CreateItem() => new Item(Game, this);
}
