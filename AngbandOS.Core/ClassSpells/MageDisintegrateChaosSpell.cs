internal class MageDisintegrateChaosSpell : ClassSpell
{
    private MageDisintegrateChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDisintegrate);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 100;
}