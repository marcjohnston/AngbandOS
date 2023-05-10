[Serializable]
internal class CultistElderSignLifeSpell : ClassSpell
{
    private CultistElderSignLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellElderSign);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 70;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 5;
}