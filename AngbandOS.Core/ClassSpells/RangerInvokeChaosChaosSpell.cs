[Serializable]
internal class RangerInvokeChaosChaosSpell : ClassSpell
{
    private RangerInvokeChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellInvokeChaos);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 50;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 30;
}