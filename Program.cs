using System.Xml;
using System.Xml.Schema;
using Populator;

// load templates
string baseTemplate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "templates/base.xml"));
string attachmentTemplate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "templates/partials/attachment.xml"));
string documentTemplate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "templates/partials/document.xml"));

var populatedBase = XdomeaPopulator.Populate(
    new Dictionary<string, string>
    {
        ["AKTE"] = "A und A Ausbildung und Arbeit Plus GmbH",
        ["VORGANG"] = "2025 A und A Ausbildung und Arbeit Plus GmbH",
        ["TEILVORGANG_WIEDERSPRUCH"] = "Wiederspruch",
        ["DOKUMENTE_WIEDERSPRUCH"] = XdomeaPopulator.Populate(
    new Dictionary<string, string>
    {
        ["DOCUMENT_ID"] = Guid.NewGuid().ToString(),
        ["DOCUMENT_NAME"] = "jahr_mm_tt:Wiederspruch Firma",
        ["ATTACHMENTS"] = XdomeaPopulator.PopulateList(
    new List<Dictionary<string, string>>
    {
        new() { ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt", ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt" },
        new() { ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt", ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt" }
    },
    attachmentTemplate
)
    },
    documentTemplate
)
    },
    baseTemplate
);

string xsdPath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xsd"), "xdomea.xsd");

var isValid = IsValid(populatedBase, xsdPath);

Console.WriteLine($"XML is valid: {isValid}");
File.WriteAllText("output.xml", populatedBase);

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