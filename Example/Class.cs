using Example.Generated;

namespace Example;

public class SuperClass(GeneratedClass generated)
{
    public override string ToString()
    {
        return generated.ToString();
    }
}
