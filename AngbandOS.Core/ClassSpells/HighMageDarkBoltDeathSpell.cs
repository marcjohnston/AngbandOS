[Serializable]
internal class HighMageDarkBoltDeathSpell : ClassSpell
{
    private HighMageDarkBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarkBolt);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 15;
}