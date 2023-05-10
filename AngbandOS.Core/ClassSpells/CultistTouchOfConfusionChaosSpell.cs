[Serializable]
internal class CultistTouchOfConfusionChaosSpell : ClassSpell
{
    private CultistTouchOfConfusionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTouchOfConfusion);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 2;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 1;
}