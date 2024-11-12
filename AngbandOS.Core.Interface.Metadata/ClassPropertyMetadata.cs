namespace AngbandOS.Core.Interface;

public class ClassPropertyMetadata : PropertyMetadata
{
    public ClassPropertyMetadata() : base("", "") { }

    public new string? EntityNounTitle
    {
        get => base.EntityNounTitle;
        set => base.EntityNounTitle = value;
    }

    public new string? EntityNamePropertyName
    {
        get => base.EntityNamePropertyName;
        set => base.EntityNamePropertyName = value;
    }

    public new string? EntityKeyPropertyName
    {
        get => base.EntityKeyPropertyName;
        set => base.EntityKeyPropertyName = value;
    }
}