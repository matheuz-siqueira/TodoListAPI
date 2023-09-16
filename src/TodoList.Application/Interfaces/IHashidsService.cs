namespace TodoList.Application.Interfaces;

public interface IHashidsService
{
    string Encode(int id);
    int Decode(string id);
    void IsHash(string id);
}
