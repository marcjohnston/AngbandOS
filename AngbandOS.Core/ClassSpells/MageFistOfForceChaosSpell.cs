internal class MageFistOfForceChaosSpell : ClassSpell
{
    private MageFistOfForceChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFistOfForce);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 9;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 6;
}