[Serializable]
internal class CultistHealingTrueLifeSpell : ClassSpell
{
    private CultistHealingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealingTrue);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}