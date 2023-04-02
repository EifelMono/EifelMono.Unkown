namespace Roslyn1;

public class TestWithInt
{
    public static void Run()
    {
        var _count = 0;
        var Reset = () => _count = 0;
        var IncCount = (bool incCount = false)
                => incCount ? _count++ : _count;

        #region if c# by hand
        Reset();
        var x1 = IncCount();  // this line could be in if and shorten the code
        if (x1== 0)
            Console.WriteLine("in x1={0}", x1);
        Console.WriteLine("out x1={0}", x1); // this line is possible!
        #endregion

        #region if is, var, &&, value
        Reset();
        if (IncCount() is var a1 && a1 == 0)
            Console.WriteLine("in a1={0}", a1);
        // This works!
        Console.WriteLine("out a1={0}", a1);

        if (IncCount().IsVar(out var a2) == 0)
            Console.WriteLine("in a2={0}", a2);
        // This works!
        Console.WriteLine("out a2={0}", a2);
        #endregion

        #region while c# by hand
        Reset();
        var x2 = IncCount(true); // this line could be in while and shorten the code
        while (x2< 3)
        {
            Console.WriteLine("in x2={0}", x2);
            x2 = IncCount(true); // this line could be in while and shorten the code
        }
        Console.WriteLine("out x2={0}", x2); // this line is possible!
        #endregion

        #region while is, var, &&, value
        Reset();
        while (IncCount(true) is var c1 && c1 < 3)
            Console.WriteLine("in c1={0}", c1);
        // error CS0103: The name 'c1' does not exist in the current context
        // Console.WriteLine("out c1={0}", c1);
        Console.WriteLine("out c1=not possible");

        Reset();
        while (IncCount(true).IsVar(out var c2) < 3)
            Console.WriteLine("in c2={0}", c2);
        // error CS0103: The name 'c2' does not exist in the current context
        // Console.WriteLine("out c2={0}", c2);
        Console.WriteLine("out c2=not possible");
        #endregion
    }
}
