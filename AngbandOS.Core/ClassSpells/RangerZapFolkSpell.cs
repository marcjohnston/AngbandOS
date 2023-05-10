[Serializable]
internal class RangerZapFolkSpell : ClassSpell
{
    private RangerZapFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellZap);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}