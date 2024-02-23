// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Charm an undead.
/// </summary>
[Serializable]
internal class CharmUndeadActivation : DirectionalActivation
{
    private CharmUndeadActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 33;

    public override string? PreActivationMessage => "";

    public override int RechargeTime() => 333;

    protected override bool Activate(int direction)
    {
        SaveGame.ControlOneUndead(direction, SaveGame.ExperienceLevel);
        return true;
    }

    public override int Value => 10000;

    public override string Name => "Enslave undead";

    public override string Description => $"{Name.ToLower()} every 333 turns";
}
