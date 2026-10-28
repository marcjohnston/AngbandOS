// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

internal abstract class MutationAttackType : IGetKey, IGameSerialize
{
    protected Game Game { get; }
    protected MutationAttackType(Game game)
    {
        Game = game;
    }
    public abstract string Title { get; }
    public string Key => GetType().Name;
    public string GetKey => Key;
    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return null;
    }

    public void Bind(RestoreGameState? restoreGameState)
    {
        
    }

    public abstract void ApplyToMonster(Monster monster, int damage, out bool fear, out bool monsterDies);
}
