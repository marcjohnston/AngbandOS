// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellFirstAid : Spell
{
    private NatureSpellFirstAid(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.RestoreHealth(SaveGame.DiceRoll(2, 8));
        SaveGame.TimedBleeding.AddTimer(-15);
    }

    public override string Name => "First Aid";

    protected override string LearnedDetails => "heal 2d8";
}