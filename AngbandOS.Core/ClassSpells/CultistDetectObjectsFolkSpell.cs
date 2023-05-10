[Serializable]
internal class CultistDetectObjectsFolkSpell : ClassSpell
{
    private CultistDetectObjectsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectObjects);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}