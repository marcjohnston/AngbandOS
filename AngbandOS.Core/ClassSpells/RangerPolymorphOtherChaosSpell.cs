internal class RangerPolymorphOtherChaosSpell : ClassSpell
{
    private RangerPolymorphOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphOther);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 20;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 30;
}