// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal abstract class FlaggedAction : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected FlaggedAction(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public virtual void Bind() { } // TODO: This is a special case virtual for bind because group flagged actions bind.  A flagged action doesn't support grouping.  Flagged actions will never be configurable either.  Not sure if they should be a repository.

    private bool _flag;
    public virtual void Set()
    {
        _flag = true;
    }
    public virtual void Clear()
    {
        _flag = false;
    }
    public virtual bool IsSet => _flag;
    public void Check(bool force = false)
    {
        if (IsSet || force)
        {
            Clear();
            Execute();
        }
    }
    protected abstract void Execute();
}
