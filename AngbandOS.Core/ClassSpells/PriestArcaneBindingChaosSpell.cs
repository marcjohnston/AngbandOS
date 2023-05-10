[Serializable]
internal class PriestArcaneBindingChaosSpell : ClassSpell
{
    private PriestArcaneBindingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellArcaneBinding);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 18;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 35;
}