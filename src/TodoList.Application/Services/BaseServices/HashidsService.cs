using HashidsNet;
using TodoList.Application.Exceptions.TodoListExceptions;
using TodoList.Application.Interfaces;

namespace TodoList.Application.Services.BaseServices;

public class HashidsService : IHashidsService
{
    private readonly IHashids _hashids;

    public HashidsService(IHashids hashids)
    {
        _hashids = hashids;
    }
    public int Decode(string id)
    {
        return _hashids.DecodeSingle(id);

    }

    public string Encode(int id)
    {
        return _hashids.Encode(id);
    }

    public void IsHash(string id)
    {
        var isHash = _hashids.TryDecodeSingle(id, out int hash);
        if (!isHash)
        {
            throw new InvalidIDException("invalid id");
        }
    }
}
