using System.Xml;
using System.Xml.Schema;
using Populator;

// load templates
var baseTemplate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "templates/base.xml"));
var attachmentTemplate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "templates/partials/attachment.xml"));
var documentTemplate = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "templates/partials/document.xml"));

var populatedBase = XdomeaPopulator.Populate(
    new Dictionary<string, string>
    {
        ["PROZESS_ID"] = Guid.NewGuid().ToString(),
        ["ERSTELLUNGS_ZEITPUNKT"] = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
        ["TAETIGKEIT"] = "Dinge Verakten",
        ["EMPFANGS_BESTAETIGUNG"] = "true",
        ["IMPORT_BESTAETIGUNG"] = "true",
        ["ERSTELLER_KENNUNG"] = "Match",
        ["ERSTELLER_ROLLE"] = "MATCH ROLE",
        ["FACHVERFAHREN_OBJEKT_ID"] = Guid.NewGuid().ToString(),
        ["AKTE_ID"]= Guid.NewGuid().ToString(),
        ["AKTE_BETREFF"] = "A und A Ausbildung und Arbeit Plus GmbH",
        ["AKTE_FERDERFUEHRUNG"] ="Bundesagentur für Arbeit",
        ["AKTE_AKTENFUEHRUNG"] = "Landesagentur für Arbeit Bayern",
        ["AKTE_BEMERKUNG"] = "Automatisch erzeugte Akte für Testzwecke",
        ["VORGANG"] = "2025 A und A Ausbildung und Arbeit Plus GmbH",
        ["TEILVORGANG_WIEDERSPRUCH"] = "Wiederspruch",
        ["TEILVORGANG_KLAGEVERFAHREN"] = "Klageverfahren",
        ["TEILVORGANG_ORDNUNGSWIEDRIGKEIT"] = "Ordnungswidrigkeit",
        ["DOKUMENT_WIEDERSPRUCH"] = XdomeaPopulator.Populate(
            new Dictionary<string, string>
            {
                ["DOCUMENT_ID"] = Guid.NewGuid().ToString(),
                ["DOCUMENT_NAME"] = "jahr_mm_tt:Wiederspruch Firma",
                ["ATTACHMENTS"] = XdomeaPopulator.PopulateList(
                    new List<Dictionary<string, string>>
                    {
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        },
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        }
                    },
                    attachmentTemplate
                )
            },
            documentTemplate
        ),
        ["DOKUMENT_KLAGEVERFAHREN"] = XdomeaPopulator.Populate(
            new Dictionary<string, string>
            {
                ["DOCUMENT_ID"] = Guid.NewGuid().ToString(),
                ["DOCUMENT_NAME"] = "jahr_mm_tt:Klageverfahren Firma",
                ["ATTACHMENTS"] = XdomeaPopulator.PopulateList(
                    new List<Dictionary<string, string>>
                    {
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        },
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        }
                    },
                    attachmentTemplate
                )
            },
            documentTemplate
        ),
        ["DOKUMENT_ORDNUNGSWIEDRIGKEIT"] = XdomeaPopulator.Populate(
            new Dictionary<string, string>
            {
                ["DOCUMENT_ID"] = Guid.NewGuid().ToString(),
                ["DOCUMENT_NAME"] = "jahr_mm_tt:Ordnungswiedrigkeit  Firma",
                ["ATTACHMENTS"] = XdomeaPopulator.PopulateList(
                    new List<Dictionary<string, string>>
                    {
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        },
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        }
                    },
                    attachmentTemplate
                )
            },
            documentTemplate
        ),
        ["DOKUMENT_MELDUNG"] = XdomeaPopulator.Populate(
            new Dictionary<string, string>
            {
                ["DOCUMENT_ID"] = Guid.NewGuid().ToString(),
                ["DOCUMENT_NAME"] = "jahr_mm_tt:Meldung Firma",
                ["ATTACHMENTS"] = XdomeaPopulator.PopulateList(
                    new List<Dictionary<string, string>>
                    {
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        },
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        }
                    },
                    attachmentTemplate
                )
            },
            documentTemplate
        ),
        ["DOKUMENT_BESCHEID"] = XdomeaPopulator.Populate(
            new Dictionary<string, string>
            {
                ["DOCUMENT_ID"] = Guid.NewGuid().ToString(),
                ["DOCUMENT_NAME"] = "jahr_mm_tt:Bescheid Firma",
                ["ATTACHMENTS"] = XdomeaPopulator.PopulateList(
                    new List<Dictionary<string, string>>
                    {
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        },
                        new()
                        {
                            ["ATTACHMENT_ID"] = Guid.NewGuid().ToString(), ["ATTACHMENT_EXTENSION"] = "txt",
                            ["ATTACHMENT_FILENAME"] = "10000000-0000-0000-0000-000000000000_file.txt"
                        }
                    },
                    attachmentTemplate
                )
            },
            documentTemplate
        )
    },
    baseTemplate
);

var xsdPath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xsd"), "xdomea.xsd");

var isValid = IsValid(populatedBase, xsdPath);

Console.WriteLine($"XML is valid: {isValid}");
File.WriteAllText("output.xml", populatedBase);
return;

/**
 * Validates an XML string against an XSD schema located at xsdPath.
 **/

bool IsValid(string xml, string xsdPath)
{
    var isValid = true;
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
    while (xmlReader.Read())
    {
    }

    return isValid;
}