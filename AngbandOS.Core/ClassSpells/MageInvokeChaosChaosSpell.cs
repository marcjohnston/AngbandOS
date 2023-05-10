[Serializable]
internal class MageInvokeChaosChaosSpell : ClassSpell
{
    private MageInvokeChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellInvokeChaos);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 40;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 40;
}