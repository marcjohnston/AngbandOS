[Serializable]
internal class CultistDetectDoorsAndTrapsFolkSpell : ClassSpell
{
    private CultistDetectDoorsAndTrapsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectDoorsAndTraps);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 7;
}