// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Charm a monster.
/// </summary>
[Serializable]
internal class CharmMonster1xEvery400Activation : DirectionalActivation
{
    private CharmMonster1xEvery400Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => "";

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        SaveGame.CharmMonster(direction, SaveGame.ExperienceLevel);
        return true;
    }

    public override int Value => 10000;

    public override string Name => "Charm monster";

    public override string Frequency => "400";
}
