[Serializable]
internal class PriestCallChaosChaosSpell : ClassSpell
{
    private PriestCallChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallChaos);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 45;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 100;
}