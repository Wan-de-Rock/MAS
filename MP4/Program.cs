using MP4;

var person1 = new Person("Misha", "00320512995");
Person person2 = null;
try
{
    person2 = new Person("Sasha", "0032051299a");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

person1.Pesel = "03301512921"; // Attribute
person2 = new Person("Sasha", "00320512995");
try
{
    person2.Pesel = "03301512921"; // Unique
}
catch (Exception e)
{
    Console.WriteLine(e.Message);	
}


Console.WriteLine(person1);
Console.WriteLine(person2);