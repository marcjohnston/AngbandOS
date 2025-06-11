namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class GenderGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    public virtual string Title { get; set; }
    public virtual string Winner { get; set; } // TODO ... this winner title to describe the type of winner is not rendered

    public virtual bool CanBeRandomlySelected { get; set; }
}
