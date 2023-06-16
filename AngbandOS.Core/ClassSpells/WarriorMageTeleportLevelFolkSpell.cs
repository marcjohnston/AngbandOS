// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class WarriorMageTeleportLevelFolkSpell : ClassSpell
{
    private WarriorMageTeleportLevelFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleportLevel);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 38;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 25;
}