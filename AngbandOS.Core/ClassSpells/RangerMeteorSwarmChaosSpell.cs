[Serializable]
internal class RangerMeteorSwarmChaosSpell : ClassSpell
{
    private RangerMeteorSwarmChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMeteorSwarm);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 45;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 35;
}