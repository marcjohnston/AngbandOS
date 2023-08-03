// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollProtectionFromEvil : ScrollItemClass
{
    private ScrollProtectionFromEvil(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override string Name => "Protection from Evil";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 250;
    public override string FriendlyName => "Protection from Evil";
    public override int Level => 30;
    public override int[] Locale => new int[] { 30, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        int i = 3 * SaveGame.ExperienceLevel;
        if (SaveGame.TimedProtectionFromEvil.AddTimer(SaveGame.Rng.DieRoll(25) + i))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new ProtectionFromEvilScrollItem(SaveGame);
}
