[Serializable]
internal class PriestMeteorSwarmChaosSpell : ClassSpell
{
    private PriestMeteorSwarmChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMeteorSwarm);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 37;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 35;
}