// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CantripsforBeginnersFolkBookItemFactory : FolkBookItemFactory
{
    private CantripsforBeginnersFolkBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightPurple;
    public override string Name => "[Cantrips for Beginners]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Cantrips for Beginners]";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new CantripsforBeginnersFolkBookItem(SaveGame);
    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<FolkSpellZap>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellWizardLock>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellDetectInvisibility>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellDetectMonsters>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellBlink>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellLightArea>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellTrapAndDoorDestruction>(),
        SaveGame.SingletonRepository.Spells.Get<FolkSpellCureLightWounds>(),
    };
}