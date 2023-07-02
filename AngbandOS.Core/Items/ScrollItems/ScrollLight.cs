// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollLight : ScrollItemClass
{
    private ScrollLight(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override string Name => "Light";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 15;
    public override string FriendlyName => "Light";
    public override int[] Locale => new int[] { 0, 3, 10, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (eventArgs.SaveGame.LightArea(Program.Rng.DiceRoll(2, 8), 2))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new LightScrollItem(SaveGame);
}
