using System.Collections.Generic;

public class Components<T>
{
    private readonly Dictionary<string, T> m_components = new();

    public T Get(string name)
    {
        return m_components[name];
    }

    public void Add(string name, T component)
    {
        m_components.Add(name, component);
    }
}
