internal class FanaticDoomBoltChaosSpell : ClassSpell
{
    private FanaticDoomBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDoomBolt);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 18;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 11;
}