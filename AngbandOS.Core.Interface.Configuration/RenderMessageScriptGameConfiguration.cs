namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RenderMessageScriptGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    public virtual string Message { get; set; }
    public virtual bool UsesItem { get; set; } = false;
    public virtual bool IdentifiesItem { get; set; } = false;
}