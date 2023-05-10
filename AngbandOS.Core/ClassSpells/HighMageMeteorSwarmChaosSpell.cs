[Serializable]
internal class HighMageMeteorSwarmChaosSpell : ClassSpell
{
    private HighMageMeteorSwarmChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMeteorSwarm);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 30;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 35;
}