// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Scare monsters with a 40+level strength.
/// </summary>
[Serializable]
internal class TerrorActivation : Activation
{
    private TerrorActivation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 75;

    public override int RechargeTime(Player player) => 3 * (player.ExperienceLevel + 10);

    public override bool Activate()
    {
        SaveGame.TurnMonsters(40 + SaveGame.Player.ExperienceLevel);
        return true;
    }

    public override int Value => 2500;

    public override string Description => "terror every 3 * (level+10) turns";

    public override Action<IItemCharacteristics> ActivateSpecialSustain => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr = true;

    public override Action<IItemCharacteristics> ActivateSpecialPower => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight = true;

    public override Action<IItemCharacteristics> ActivateSpecialAbility => (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct = true;
}
