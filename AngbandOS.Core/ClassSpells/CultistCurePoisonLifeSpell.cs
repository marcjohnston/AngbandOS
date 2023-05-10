[Serializable]
internal class CultistCurePoisonLifeSpell : ClassSpell
{
    private CultistCurePoisonLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCurePoison);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}