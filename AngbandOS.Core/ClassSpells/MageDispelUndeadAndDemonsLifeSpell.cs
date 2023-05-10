[Serializable]
internal class MageDispelUndeadAndDemonsLifeSpell : ClassSpell
{
    private MageDispelUndeadAndDemonsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelUndeadAndDemons);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 33;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 75;
}