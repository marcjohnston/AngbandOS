// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Fill us up.
/// </summary>
[Serializable]
internal class SatiateActivation : Activation
{
    private SatiateActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 85;

    public override bool Activate()
    {
        SaveGame.Player.SetFood(Constants.PyFoodMax - 1);
        return true;
    }

    public override int RechargeTime(Player player) => 200;

    public override int Value => 2000;

    public override string Description => "satisfy hunger every 200 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife = true;
}
