[Serializable]
internal class CultistDetectionFolkSpell : ClassSpell
{
    private CultistDetectionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetection);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 45;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}