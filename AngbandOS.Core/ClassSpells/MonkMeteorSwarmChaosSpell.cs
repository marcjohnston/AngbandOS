[Serializable]
internal class MonkMeteorSwarmChaosSpell : ClassSpell
{
    private MonkMeteorSwarmChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMeteorSwarm);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 35;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 35;
}