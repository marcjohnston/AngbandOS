[Serializable]
internal class MageProtectionFromEvilLifeSpell : ClassSpell
{
    private MageProtectionFromEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellProtectionFromEvil);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 23;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}