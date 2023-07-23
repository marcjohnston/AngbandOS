// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Map the local area.
/// </summary>
[Serializable]
internal class MapLightActivation : Activation
{
    private MapLightActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 101;

    public override string? PreActivationMessage => "It shines brightly...";

    public override bool Activate()
    {
        SaveGame.MapArea();
        SaveGame.LightArea(Program.Rng.DiceRoll(2, 15), 3);
        return true;
    }

    public override int RechargeTime() => Program.Rng.RandomLessThan(50) + 50;

    public override int Value => 500;

    public override string Description => "light (dam 2d15) & map area every 50+d50 turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResSound = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather = true;
}
