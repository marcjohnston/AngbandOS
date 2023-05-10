[Serializable]
internal class WarriorMageTerrorDeathSpell : ClassSpell
{
    private WarriorMageTerrorDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellTerror);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 21;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 10;
}