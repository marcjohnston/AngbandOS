internal class FanaticMeteorSwarmChaosSpell : ClassSpell
{
    private FanaticMeteorSwarmChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMeteorSwarm);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 35;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 35;
}