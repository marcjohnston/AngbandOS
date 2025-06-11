namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class GodGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    public virtual string LongName { get; set; }
    public virtual string ShortName { get; set; }
    public virtual string FavorDescription { get; set; }
}