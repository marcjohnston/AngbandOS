// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Turn an item to gold.
/// </summary>
[Serializable]
internal class AlchemyActivation : Activation
{
    private AlchemyActivation(SaveGame saveGame) : base(saveGame) { }

    public override int RandomChance => 5;

    public override string? PreActivationMessage => "It glows bright yellow...";

    public override bool Activate()
    {
        SaveGame.Alchemy();
        return true;
    }

    public override int RechargeTime() => 500;

    public override int Value => 10000;

    public override string Description => "alchemy every 500 turns";
}
