using Populator;

string template = @"
<Config>
    <NAME>${NAME}</NAME>
    <IP_ADDRESS>${IP_ADDRESS}</IP_ADDRESS>
    <Attachments>${ATTACHMENTS}<Attachments>
</Config>";

var listTemplate = @"
<Attchment>
  <Name>${NAME}</Name>
  <File>${FILE}</File>
</Attchment>
";

KeyValuePair<string, string>[][]  listvars =
{
    new KeyValuePair<string, string>[]
    {
        new("NAME", "Attachment1"),
        new("FILE", "attachment1.txt")
    },
    new KeyValuePair<string, string>[]
    {
        new("NAME", "attachment2"),
        new("FILE", "attachment2.txt")
    },
};


var xdomeavars = new[]
{
    KeyValuePair.Create("IP_ADDRESS", "192.168.2.1"),
    KeyValuePair.Create("NAME", "John DOE"),
    KeyValuePair.Create("ATTACHMENTS", XdomeaPopulator.PopulateList(listvars,listTemplate))
};

Console.WriteLine(XdomeaPopulator.Populate(xdomeavars,template));
