// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DarknessScrollItemFactory : ScrollItemFactory
{
    private DarknessScrollItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Darkness";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Darkness";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (!SaveGame.HasBlindnessResistance && !SaveGame.HasDarkResistance)
        {
            SaveGame.TimedBlindness.AddTimer(3 + SaveGame.DieRoll(5));
        }
        if (SaveGame.UnlightArea(10, 3))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
