[Serializable]
internal class HighMageManaStormChaosSpell : ClassSpell
{
    private HighMageManaStormChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaStorm);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 45;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 200;
}