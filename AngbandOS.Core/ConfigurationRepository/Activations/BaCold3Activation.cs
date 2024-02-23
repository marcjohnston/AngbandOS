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
internal class BaCold3Activation : DirectionalActivation
{
    private BaCold3Activation(SaveGame saveGame) : base(saveGame) { }
    public override int RandomChance => 50;

    public override string? PreActivationMessage => "Your {0} glows bright white...";

    public override int RechargeTime() => SaveGame.RandomLessThan(325) + 325;

    protected override bool Activate(int direction)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), direction, 200, 3);
        return true;
    }

    public override int Value => 2500;
    public override string Name => "Ball of cold (200)";

    public override string Description => $"{Name.ToLower()} every 325+d325 turns";
}
