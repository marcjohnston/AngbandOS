[Serializable]
internal class RangerCallChaosChaosSpell : ClassSpell
{
    private RangerCallChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallChaos);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 48;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 100;
}