using Populator;

// load template
string template = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "template.xml"));

var attachmentTemplate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "attachment_template.xml"));

// KeyValuePair<string, string>[][] listvars =
// {
//     new KeyValuePair<string, string>[]
//     {
//         new("NAME", "Attachment1"),
//         new("FILE", "attachment1.txt")
//     },
//     new KeyValuePair<string, string>[]
//     {
//         new("NAME", "attachment2"),
//         new("FILE", "attachment2.txt")
//     },
// };


KeyValuePair<string, string>[][] listvars = Array.Empty<KeyValuePair<string, string>[]>();


var xdomeavars = new[]
{
    KeyValuePair.Create("AKTE", "A und A Ausbildung und Arbeit Plus GmbH"),
    KeyValuePair.Create("VORGANG", "2025 A und A Ausbildung und Arbeit Plus GmbH"),
    KeyValuePair.Create("TEILVORGANG_WIEDERSPRUCH", "Wiederspruch"),
    //KeyValuePair.Create("DOKUMENTE_WIEDERSPRUCH", XdomeaPopulator.PopulateList(listvars,attachmentTemplate))
    KeyValuePair.Create("DOKUMENTE_WIEDERSPRUCH", attachmentTemplate)
};

var populated = XdomeaPopulator.Populate(xdomeavars, template);
Console.WriteLine(populated);
File.WriteAllText("output.xml", populated);