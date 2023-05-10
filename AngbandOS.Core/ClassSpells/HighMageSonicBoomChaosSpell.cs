[Serializable]
internal class HighMageSonicBoomChaosSpell : ClassSpell
{
    private HighMageSonicBoomChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSonicBoom);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 11;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 10;
}