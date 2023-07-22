// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellBless : Spell
{
    private LifeSpellBless(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TimedBlessing.AddTimer(Program.Rng.DieRoll(12) + 12);
    }

    public override string Name => "Bless";
    
    protected override string? Info()
    {
        return "dur 12+d12 turns";
    }
}