namespace Application.Interfaces;

public interface IScreen
{
    void drawScreen();
    Task<string> readInput();
}
