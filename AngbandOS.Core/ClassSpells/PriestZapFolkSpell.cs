[Serializable]
internal class PriestZapFolkSpell : ClassSpell
{
    private PriestZapFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellZap);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}