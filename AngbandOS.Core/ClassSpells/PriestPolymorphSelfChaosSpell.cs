internal class PriestPolymorphSelfChaosSpell : ClassSpell
{
    private PriestPolymorphSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphSelf);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 55;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}