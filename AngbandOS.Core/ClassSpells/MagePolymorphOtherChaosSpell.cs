internal class MagePolymorphOtherChaosSpell : ClassSpell
{
    private MagePolymorphOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphOther);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 7;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 9;
}