[Serializable]
internal class WarriorMageProtectFromCorrosionNatureSpell : ClassSpell
{
    private WarriorMageProtectFromCorrosionNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellProtectFromCorrosion);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 95;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}