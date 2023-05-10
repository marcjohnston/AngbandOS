[Serializable]
internal class PaladinDispelUndeadAndDemonsLifeSpell : ClassSpell
{
    private PaladinDispelUndeadAndDemonsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelUndeadAndDemons);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 75;
}