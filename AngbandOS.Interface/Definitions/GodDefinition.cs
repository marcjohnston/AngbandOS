namespace AngbandOS.Core.Interface.Definitions;

[Serializable]
public class GodDefinition : IPoco
{
    public virtual string LongName { get; set; }
    public virtual string ShortName { get; set; }

    public virtual string FavorDescription { get; set; }

    public virtual string Key { get; set; }

    public bool IsValid()
    {
        return true;
    }
}

