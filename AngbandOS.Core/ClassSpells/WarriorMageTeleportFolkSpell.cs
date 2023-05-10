[Serializable]
internal class WarriorMageTeleportFolkSpell : ClassSpell
{
    private WarriorMageTeleportFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTeleport);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 8;
}