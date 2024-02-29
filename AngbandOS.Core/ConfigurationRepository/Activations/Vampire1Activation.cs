// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Drain up to 50 life from an opponent, and give it to the player.
/// </summary>
[Serializable]
internal class Vampire1Activation : DirectionalActivation
{
    private Vampire1Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 66;

    public override int RechargeTime() => 400;

    protected override bool Activate(int direction)
    {
        for (int i = 0; i < 3; i++)
        {
            if (SaveGame.DrainLife(direction, 50))
            {
                SaveGame.RestoreHealth(50);
            }
        }
        return true;
    }

    public override int Value => 1000;

    public override string Name => "Vampiric drain 3x (50)";

    public override string Frequency => "400";
}
