// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class DispelUndeadAndDemonsLifeSpell : Spell
{
    private DispelUndeadAndDemonsLifeSpell(Game game) : base(game) { }

    public override string Name => "Dispel Undead & Demons";

    protected override string LearnedDetails => $"dam {3 * Game.ExperienceLevel.IntValue}+{3 * Game.ExperienceLevel.IntValue}";
}