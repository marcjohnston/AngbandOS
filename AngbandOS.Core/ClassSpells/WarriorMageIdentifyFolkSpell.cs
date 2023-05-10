internal class WarriorMageIdentifyFolkSpell : ClassSpell
{
    private WarriorMageIdentifyFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellIdentify);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 40;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}