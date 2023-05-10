[Serializable]
internal class HighMageProtectionFromEvilLifeSpell : ClassSpell
{
    private HighMageProtectionFromEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellProtectionFromEvil);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 19;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}