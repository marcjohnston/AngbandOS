// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Hooks;

internal abstract class Hook<T> where T : HookArgs
{
    public SaveGame SaveGame { get; }

    public Hook(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract void Execute(T hookArgs);
}

internal abstract class HookArgs
{

}

internal class PlayerHitByProjectileHook : Hook<PlayerHitByProjectileHookArgs>
{
    public PlayerHitByProjectileHook(SaveGame saveGame) : base(saveGame) { }

    public override void Execute(PlayerHitByProjectileHookArgs hookArgs)
    {
    }
}

internal class PlayerHitByProjectileHookArgs : HookArgs
{
    public int Damage;

    public PlayerHitByProjectileHookArgs(int damage)
    {
        Damage = damage;
    }
}
