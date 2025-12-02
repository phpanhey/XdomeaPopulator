using Populator;

// load template
string template = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "template.xml"));

var listTemplate = @"
<Attchment>
  <Name>${NAME}</Name>
  <File>${FILE}</File>
</Attchment>
";

KeyValuePair<string, string>[][] listvars =
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
    KeyValuePair.Create("AKTE", "A und A Ausbildung und Arbeit Plus GmbH"),
    KeyValuePair.Create("VORGANG", "2025 A und A Ausbildung und Arbeit Plus GmbH"),
    KeyValuePair.Create("ATTACHMENTS", XdomeaPopulator.PopulateList(listvars,listTemplate))
};

var populated = XdomeaPopulator.Populate(xdomeavars, template);
Console.WriteLine(populated);
File.WriteAllText("output.xml", populated);