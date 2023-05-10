[Serializable]
internal class WarriorMageFrostBoltNatureSpell : ClassSpell
{
    private WarriorMageFrostBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellFrostBolt);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 13;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}