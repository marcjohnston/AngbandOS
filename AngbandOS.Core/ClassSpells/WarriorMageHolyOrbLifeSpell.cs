internal class WarriorMageHolyOrbLifeSpell : ClassSpell
{
    private WarriorMageHolyOrbLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyOrb);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 26;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}