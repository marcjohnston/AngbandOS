[Serializable]
internal class MonkInvokeChaosChaosSpell : ClassSpell
{
    private MonkInvokeChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellInvokeChaos);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 50;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 40;
}