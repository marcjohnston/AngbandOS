[Serializable]
internal class CultistHealingLifeSpell : ClassSpell
{
    private CultistHealingLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealing);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 33;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 5;
}