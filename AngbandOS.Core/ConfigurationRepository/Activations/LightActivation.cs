// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Light the area.
/// </summary>
[Serializable]
internal class LightActivation : Activation
{
    private LightActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "It wells with clear light...";

    public override bool Activate()
    {
        SaveGame.LightArea(SaveGame.DiceRoll(2, 15), 3);
        return true;
    }

    public override int RechargeTime() => SaveGame.RandomLessThan(10) + 10;

    public override int Value => 150;

    public override string Description => "light area (dam 2d15) every 10+d10 turns";
}
