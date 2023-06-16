// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Drain 100 health from an opponent, and give it to the player.
/// </summary>
[Serializable]
internal class Vampire2Activation : DirectionalActivation
{
    private Vampire2Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 50;

    public override string? PreActivationMessage => ""; // This command does not display a message.

    public override int RechargeTime(Player player) => 400;

    protected override bool Activate(int direction)
    {
        for (int i = 0; i < 3; i++)
        {
            if (SaveGame.DrainLife(direction, 100))
            {
                SaveGame.Player.RestoreHealth(100);
            }
        }
        return true;
    }

    public override int Value => 2500;

    public override string Description => "vampiric drain (3*100) every 400 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest = true;
}
