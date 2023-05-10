[Serializable]
internal class CultistExorcismLifeSpell : ClassSpell
{
    private CultistExorcismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellExorcism);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}