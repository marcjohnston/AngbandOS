[Serializable]
internal class MonkCallChaosChaosSpell : ClassSpell
{
    private MonkCallChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallChaos);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 44;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 100;
}