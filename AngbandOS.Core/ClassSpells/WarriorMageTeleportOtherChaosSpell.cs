internal class WarriorMageTeleportOtherChaosSpell : ClassSpell
{
    private WarriorMageTeleportOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportOther);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 35;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}