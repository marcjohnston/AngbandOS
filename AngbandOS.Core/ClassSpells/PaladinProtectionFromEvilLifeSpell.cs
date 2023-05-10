[Serializable]
internal class PaladinProtectionFromEvilLifeSpell : ClassSpell
{
    private PaladinProtectionFromEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellProtectionFromEvil);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}