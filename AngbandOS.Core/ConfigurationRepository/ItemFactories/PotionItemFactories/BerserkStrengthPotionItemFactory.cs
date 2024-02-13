// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BerserkStrengthPotionItemFactory : PotionItemFactory
{
    private BerserkStrengthPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Berserk Strength";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Berserk Strength";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;

        // Berserk strength removes fear, heals 30 health, and gives you timed super heroism
        if (SaveGame.TimedFear.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.TimedSuperheroism.AddTimer(SaveGame.DieRoll(25) + 25))
        {
            identified = true;
        }
        if (SaveGame.RestoreHealth(30))
        {
            identified = true;
        }
        return identified;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
