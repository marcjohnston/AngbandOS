[Serializable]
internal class MageTouchOfConfusionChaosSpell : ClassSpell
{
    private MageTouchOfConfusionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTouchOfConfusion);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 1;
}