using Populator;

string template ="""
<ns2:FVDaten.SGOAblegen.0605 xmlns:ns2="urn:xoev-de:xdomea:schema:3.0.0"
                             xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                             xsi:schemaLocation="urn:xoev-de:xdomea:xdomea-0605.xsd">
    <ns2:Kopf>
        <ns2:ProzessID>e6c47537-0594-4d8c-be53-89b5e84a85f6</ns2:ProzessID>
        <ns2:Nachrichtentyp>
            <code>0605</code>
        </ns2:Nachrichtentyp>
        <ns2:Erstellungszeitpunkt>2025-07-22T11:41:05.9544231+02:00</ns2:Erstellungszeitpunkt>
        <ns2:Absender/>
        <ns2:Empfaenger>
            <ns2:Taetigkeit>Dinge von A nach B schicken</ns2:Taetigkeit>
        </ns2:Empfaenger>
        <ns2:Empfangsbestaetigung>true</ns2:Empfangsbestaetigung>
        <ns2:Importbestaetigung>true</ns2:Importbestaetigung>
        <ns2:Erstellerkennung>VIC-API</ns2:Erstellerkennung>
        <ns2:ErstellerRolle>VIC-API</ns2:ErstellerRolle>
        <ns2:Stapel>true</ns2:Stapel>
        <ns2:Stapellaenge>2</ns2:Stapellaenge>
    </ns2:Kopf>
    <ns2:SchriftgutobjektZumAblegen>
        <ns2:FachverfahrenObjektID>10000000-0000-0000-0000-000000000000_file.txt</ns2:FachverfahrenObjektID>
        <ns2:Schriftgutobjekt>
            <ns2:Akte>
                <ns2:Identifikation>
                    <ns2:ID>e6c47537-0594-4d8c-be53-89b5e84a85f6</ns2:ID>
                </ns2:Identifikation>
                <ns2:AllgemeineMetadaten>
                    <ns2:Betreff>AKTE</ns2:Betreff>
                    <ns2:Kennzeichen>Kenzeichunung</ns2:Kennzeichen>
                    <ns2:Federfuehrung>Federfuehrung</ns2:Federfuehrung>
                    <ns2:Aktenfuehrung>2023</ns2:Aktenfuehrung>
                    <ns2:Bemerkung>2023</ns2:Bemerkung>
                    <ns2:Medium>
                        <code>001</code>
                    </ns2:Medium>
                    <ns2:Aktenplaneinheit>
                        <ns2:Kennzeichen>10.01.01</ns2:Kennzeichen>
                        <ns2:Inhaltsangabe>10.01.01</ns2:Inhaltsangabe>
                        <ns2:BetreffKurz>10.01.01</ns2:BetreffKurz>
                    </ns2:Aktenplaneinheit>
                </ns2:AllgemeineMetadaten>
                <ns2:Akteninhalt>
                    <ns2:Vorgang>
                        <ns2:Identifikation>
                            <ns2:ID>e6c47537-0594-4d8c-be53-89b5e84a85f6</ns2:ID>
                        </ns2:Identifikation>
                        <ns2:AllgemeineMetadaten>
                            <ns2:Betreff>VORGANG</ns2:Betreff>
                            <ns2:Medium>
                                <code>001</code>
                            </ns2:Medium>
                        </ns2:AllgemeineMetadaten>
                        <ns2:Aktenbetreff>E</ns2:Aktenbetreff>
                        <ns2:Dokument>
                            <ns2:Identifikation>
                                <ns2:ID>e6c47537-0594-4d8c-be53-89b5e84a85f6</ns2:ID>
                            </ns2:Identifikation>
                            <ns2:AllgemeineMetadaten>
                                <ns2:Betreff>DOKUMENT</ns2:Betreff>
                                <ns2:Medium>
                                    <code>001</code>
                                </ns2:Medium>
                            </ns2:AllgemeineMetadaten>
                        </ns2:Dokument>
                    </ns2:Vorgang>
                </ns2:Akteninhalt>
            </ns2:Akte>
        </ns2:Schriftgutobjekt>
        <ns2:Ablageort>VIS API Test</ns2:Ablageort>
    </ns2:SchriftgutobjektZumAblegen>
</ns2:FVDaten.SGOAblegen.0605>
"""; 

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
    KeyValuePair.Create("AKTE", "A und A Ausbildung und Arbeit Plus GmbH"),
    KeyValuePair.Create("VORGANG", "2025 A und A Ausbildung und Arbeit Plus GmbH"),
    KeyValuePair.Create("ATTACHMENTS", XdomeaPopulator.PopulateList(listvars,listTemplate))
};

var populated = XdomeaPopulator.Populate(xdomeavars,template);
Console.WriteLine(populated);
File.WriteAllText("output.xml", populated);