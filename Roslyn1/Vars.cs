namespace Roslyn1;

public static class Vars
{
    public static T IsVar<T>(this T inValue, out T outValue)
        => outValue = inValue;
}
