[Serializable]
internal class HighMageMagicMissileChaosSpell : ClassSpell
{
    private HighMageMagicMissileChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellMagicMissile);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 4;
}