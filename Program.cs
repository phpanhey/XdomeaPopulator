using System.Xml;
using System.Xml.Schema;
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

string xsdPath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xsd"), "xdomea.xsd");

var isValid = IsValid(populated, xsdPath);

Console.WriteLine($"XML is valid: {isValid}");
File.WriteAllText("output.xml", populated);




/**
 * Validates an XML string against an XSD schema located at xsdPath.
 **/

bool IsValid(string xml, string xsdPath)
{
    bool isValid = true;    
    var schemaSet = new XmlSchemaSet
    {
        XmlResolver = new XmlUrlResolver() 
    };    
    var xsdSettings = new XmlReaderSettings
    {
        XmlResolver = new XmlUrlResolver()
    };

    using (var xsdReader = XmlReader.Create(xsdPath, xsdSettings))
    {
        schemaSet.Add(null, xsdReader); 
    }
    
    schemaSet.Compile();

    var settings = new XmlReaderSettings
    {
        Schemas = schemaSet,
        ValidationType = ValidationType.Schema
    };

    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

    settings.ValidationEventHandler += (sender, e) =>
    {
        isValid = false;
        Console.WriteLine($"{e.Severity}: {e.Message}");
    };    
    using var stringReader = new StringReader(xml);
    using var xmlReader = XmlReader.Create(stringReader, settings);
    while (xmlReader.Read()) { }
    return isValid;
}