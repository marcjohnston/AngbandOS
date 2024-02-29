// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Charm an animal.
/// </summary>
[Serializable]
internal class CharmAnimal1xEvery300Activation : DirectionalActivation
{
    private CharmAnimal1xEvery300Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 50;

    public override string? PreActivationMessage => "";

    public override int RechargeTime() => 300;

    protected override bool Activate(int direction)
    {
        SaveGame.CharmAnimal(direction, SaveGame.ExperienceLevel);
        return true;
    }

    public override int Value => 7500;

    public override string Name => "Charm animal";

    public override string Frequency => "300";
}
