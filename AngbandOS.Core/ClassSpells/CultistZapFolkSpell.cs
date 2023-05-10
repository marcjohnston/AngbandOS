[Serializable]
internal class CultistZapFolkSpell : ClassSpell
{
    private CultistZapFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellZap);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}