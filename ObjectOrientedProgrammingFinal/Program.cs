using ObjectOrientedProgrammingFinal;

Game game=new Game();
try
{
    game.Start();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
 }
