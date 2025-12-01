```shell
 dotnet run; cp .\output.xml ./script; mv .\script\output.xml ./script/10000000-0000-0000-0000-000000000000_FVDaten.SGOAblegen.0605.xml;cd script;python ./make_request.py;rm 10000000-0000-0000-0000-000000000000_FVDaten.SGOAblegen.0605.xml; cd ../
 ```



    // Veraktung
        //      A Name des Unternehmens : A & A Ausbildung und Arbeit Plus GmbH
        //          V NameUnternehmen : {Jahr} {Firma} : 2025 A & A Ausbildung und Arbeit Plus GmbH
        //              SV Wiederspruch
        //                  D jahr_mm_tt:Wiederspruch Firma 
        //              SV Klageverfahren
        //                  D jahr_mm_tt:Klageverfahren Firma
        //              SV Ordnungswiedrigkeit
        //                  D jahr_mm_tt:Ordnungswiedrigkeit Firma
        //              DE Meldung : 2025_MM_TT:Meldung Unternehmensname
        //              DA Bescheid : 2025_MM_TT:Bescheid Unternehmensname
        
