[Serializable]
internal class MageZapFolkSpell : ClassSpell
{
    private MageZapFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellZap);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}