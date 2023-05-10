[Serializable]
internal class MageMeteorSwarmChaosSpell : ClassSpell
{
    private MageMeteorSwarmChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMeteorSwarm);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 32;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 35;
}