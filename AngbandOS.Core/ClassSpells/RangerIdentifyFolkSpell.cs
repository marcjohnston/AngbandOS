[Serializable]
internal class RangerIdentifyFolkSpell : ClassSpell
{
    private RangerIdentifyFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellIdentify);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 38;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}