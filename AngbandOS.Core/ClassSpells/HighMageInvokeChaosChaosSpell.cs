[Serializable]
internal class HighMageInvokeChaosChaosSpell : ClassSpell
{
    private HighMageInvokeChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellInvokeChaos);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 35;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 40;
}