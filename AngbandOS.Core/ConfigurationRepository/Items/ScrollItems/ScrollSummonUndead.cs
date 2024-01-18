// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollSummonUndead : ScrollItemClass
{
    private ScrollSummonUndead(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Summon Undead";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Summon Undead";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        for (int i = 0; i < SaveGame.Rng.DieRoll(3); i++)
        {
            if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, new UndeadMonsterSelector()))
            {
                eventArgs.Identified = true;
            }
        }
    }
    public override Item CreateItem() => new SummonUndeadScrollItem(SaveGame);
}
