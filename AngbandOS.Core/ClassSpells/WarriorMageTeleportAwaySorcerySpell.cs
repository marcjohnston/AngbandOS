[Serializable]
internal class WarriorMageTeleportAwaySorcerySpell : ClassSpell
{
    private WarriorMageTeleportAwaySorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleportAway);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}