internal class RangerPolymorphSelfChaosSpell : ClassSpell
{
    private RangerPolymorphSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphSelf);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 75;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}