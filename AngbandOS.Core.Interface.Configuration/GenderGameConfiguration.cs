namespace AngbandOS.Core.Interface.Configuration;

public class GenderGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string Title { get; set; }
    public virtual string Winner { get; set; } // TODO ... this winner title to describe the type of winner is not rendered

    public virtual bool CanBeRandomlySelected { get; set; } = true;
    public virtual string Pronoun { get; set; } = "it";
    public virtual string PossessiveAdjective { get; set; } = "its";
}
