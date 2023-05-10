[Serializable]
internal class CultistDetectEvilLifeSpell : ClassSpell
{
    private CultistDetectEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectEvil);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}