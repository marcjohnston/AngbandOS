namespace AngbandOS.Core.Hooks
{
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
}
