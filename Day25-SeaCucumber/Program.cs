// See https://aka.ms/new-console-template for more information

string[] data = File.ReadAllLines("example.txt");
SeaFloor floor = new SeaFloor(data);
do
{
    Console.Clear();
    Console.WriteLine($"Sea Floor. Step: {floor.Steps}");
    Console.WriteLine(floor);
    Thread.Sleep(250);
}
while (floor.Step());
Console.WriteLine($"No change at Step: {floor.Steps}");
