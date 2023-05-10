[Serializable]
internal class MonkArcaneBindingChaosSpell : ClassSpell
{
    private MonkArcaneBindingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellArcaneBinding);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 18;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 35;
}