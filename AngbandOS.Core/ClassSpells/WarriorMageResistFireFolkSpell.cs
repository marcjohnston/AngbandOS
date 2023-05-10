[Serializable]
internal class WarriorMageResistFireFolkSpell : ClassSpell
{
    private WarriorMageResistFireFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistFire);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}