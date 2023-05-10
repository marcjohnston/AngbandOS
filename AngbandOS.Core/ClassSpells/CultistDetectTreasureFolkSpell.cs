[Serializable]
internal class CultistDetectTreasureFolkSpell : ClassSpell
{
    private CultistDetectTreasureFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectTreasure);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 10;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}