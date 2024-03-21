// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Activations;

/// <summary>
/// Shoot a frost ball that does 200 damage with a larger radius.
/// </summary>
[Serializable]
internal class StarBall150Every1000p1d325Activation : DirectionalActivation
{
    private StarBall150Every1000p1d325Activation(Game game) : base(game) { }
    public override int RandomChance => 50;

    public override string? PreActivationMessage => "Your {0} is surrounded by lightning...";

    public override int RechargeTime() => 1000;

    protected override bool Activate(int direction)
    {
        for (int i = 0; i < 8; i++)
        {
            Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), Game.OrderedDirection[i], 150, 3);
        }
        return true;
    }

    public override int Value => 8000;
    public override string Name => "Star ball (150)";

    public override string Frequency => "1000";
}
