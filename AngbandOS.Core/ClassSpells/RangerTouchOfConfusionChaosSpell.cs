internal class RangerTouchOfConfusionChaosSpell : ClassSpell
{
    private RangerTouchOfConfusionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTouchOfConfusion);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 5;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 2;
}