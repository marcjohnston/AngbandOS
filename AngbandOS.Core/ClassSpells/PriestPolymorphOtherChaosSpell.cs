internal class PriestPolymorphOtherChaosSpell : ClassSpell
{
    private PriestPolymorphOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphOther);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 11;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 9;
}