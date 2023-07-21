// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HeroismPotionItemFactory : PotionItemFactory
{
    private HeroismPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Heroism";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 35;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Heroism";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;
        // Heroism removes fear, cures 10 health, and gives you timed heroism
        if (SaveGame.Player.TimedFear.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.Player.TimedHeroism.AddTimer(Program.Rng.DieRoll(25) + 25))
        {
            identified = true;
        }
        if (SaveGame.Player.RestoreHealth(10))
        {
            identified = true;
        }
        return identified;
    }
    public override Item CreateItem() => new HeroismPotionItem(SaveGame);
}
