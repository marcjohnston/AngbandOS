// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class WarriorMageVampirismTrueDeathSpell : ClassSpell
{
    private WarriorMageVampirismTrueDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampirismTrue);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 125;
}