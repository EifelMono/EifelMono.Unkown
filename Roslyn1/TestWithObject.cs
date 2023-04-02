namespace Roslyn1;

public class TestWithObject
{
    public static void Run()
    {
        var _count = 0;
        var Reset = () => _count = 0;
        var IncCount = (bool incCount = false)
                => new
                {
                    Name = "Andreas",
                    Count = _count++,
                    Ok = incCount ? _count > 3 : true
                };

        #region if c# by hand
        Reset();
        var x1 = IncCount();  // this line could be in if and shorten the code
        if (x1.Ok)
            Console.WriteLine("in x1={0}", x1);
        Console.WriteLine("out x1={0}", x1); // this line is possible!
        #endregion

        #region if is, var, &&, poperty value
        Reset();
        if (IncCount() is var a1 && a1.Ok)
            Console.WriteLine("in a1={0}", a1);
        Console.WriteLine("out a1={0}", a1);

        Reset();
        if (IncCount().IsVar(out var a2).Ok)
            Console.WriteLine("in a2={0}", a2);
        Console.WriteLine("out a2={0}", a2);
        #endregion

        #region if is var, and, property expression
        Reset();
        if (IncCount() is var b1 and { Ok: true })
            Console.WriteLine("in b1={0}", b1);
        // error CS0165: Use of unassigned local variable 'b1'
        // Console.WriteLine("out b1={0}", b1);
        Console.WriteLine("out b1=not possible");

        Reset();
        if (IncCount().IsVar(out var b2) is { Ok: true })
            Console.WriteLine("in b2={0}", b2);
        // This works!
        Console.WriteLine("out b2={0}", b2);
        #endregion

        #region while c# by hand
        Reset();
        var x2 = IncCount(true); // this line could be in while and shorten the code
        while (!x2.Ok)
        {
            Console.WriteLine("in x2={0}", x2);
            x2 = IncCount(true); // this line could be in while and shorten the code
        }
        Console.WriteLine("out x2={0}", x2); // this line is possible!
        #endregion

        #region while is, var, &&, poperty value
        Reset();
        while (IncCount(true) is var c1 && !c1.Ok)
            Console.WriteLine("in c1={0}", c1);
        // error CS0103: The name 'c1' does not exist in the current context
        // Console.WriteLine("out c1={0}", c1);
        Console.WriteLine("out c1=not possible");

        Reset();
        while (!IncCount(true).IsVar(out var c2).Ok)
            Console.WriteLine("in c2={0}", c2);
        // error CS0103: The name 'c2' does not exist in the current context
        // Console.WriteLine("out c2={0}", c2);
        Console.WriteLine("out c2=not possible");
        #endregion

        #region while is var, and, property expression
        Reset();
        while (IncCount(true) is var d1 and { Ok: false })
            Console.WriteLine("in d1={0}", d1);
        // error CS0103: The name 'd1' does not exist in the current context
        // Console.WriteLine("out d1={0}", d1);
        Console.WriteLine("out d1=not possible");

        Reset();
        while (IncCount(true).IsVar(out var d2) is { Ok: false })
            Console.WriteLine("in d2={0}", d2);
        // error CS0103: The name 'd2' does not exist in the current context
        // Console.WriteLine("out d2={0}", d2);
        Console.WriteLine("out d2=not possible");
        #endregion
    }
}
