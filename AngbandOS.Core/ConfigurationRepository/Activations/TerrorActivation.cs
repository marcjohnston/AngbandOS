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

    public override int RechargeTime() => 3 * (SaveGame.ExperienceLevel + 10);

    public override bool Activate()
    {
        SaveGame.TurnMonsters(40 + SaveGame.ExperienceLevel);
        return true;
    }

    public override int Value => 2500;

    public override string Name => "terror";

    public override string Description => $"{Name} every 3 * (level+10) turns";
}
