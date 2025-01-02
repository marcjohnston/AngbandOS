//public class Identified
//{
//    private readonly bool _value;
//    public Identified(bool value)
//    {
//        _value = value;
//    }

//    public Identified()
//    {
//        _value = false;
//    }
//    public static implicit operator Identified(bool value) => new Identified(value);
//    public static explicit operator bool(Identified value) => value._value;
//}
//public class Success
//{
//    private readonly bool _value;
//    public Success(bool value)
//    {
//        _value = value;
//    }

//    public Success()
//    {
//        _value = false;
//    }
//    public static implicit operator Success(bool value) => new Success(value);
//    public static explicit operator bool(Success value) => value._value;
//}

//public class Test
//{
//    public void MyTest()
//    {
//        Identified identified = true;
//        Identified identified2 = true;
//        Success success = true;
//        if (identified == success)
//        {
//        }
//        if (identified == identified2)
//        {
//        }
//        if (identified)
//        {
//        }
//    }
//}