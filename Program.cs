using Populator;

string template = @"
<Config>
    <NAME>${NAME}</NAME>
    <IP_ADDRESS>${IP_ADDRESS}</IP_ADDRESS>
</Config>";

var vars = new[]
{
    KeyValuePair.Create("IP_ADDRESS", "192.168.2.1"),
    KeyValuePair.Create("NAME", "John DOE")

};

Console.WriteLine(XdomeaPopulator.Populate(vars,template));
