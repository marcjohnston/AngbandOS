// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.RenderMessageScripts;

[Serializable]

internal abstract class RenderMessageScript : Script, IUniversalScript
{
    protected RenderMessageScript(Game game) : base(game) { }

    public virtual bool UsesItem => false;
    public virtual bool IdentifiesItem => false;

    public abstract string Message { get; }

    public override void Bind() { }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();
        return new UsedResult(UsesItem);
    }

    public IdentifiedResult ExecuteAimWandScript(int dir)
    {
        ExecuteScript();
        return new IdentifiedResult(IdentifiesItem);
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        ExecuteScript();
        return new IdentifiedAndUsedResult(IdentifiesItem, UsesItem);
    }

    public void ExecuteScript()
    {
        Game.MsgPrint(Message);
    }

    /// <summary>
    /// Renders the message and returns false for both the identified and used results.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="dir"></param>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        ExecuteScript();
        return new IdentifiedAndUsedResult(IdentifiesItem, UsesItem);
    }
}
