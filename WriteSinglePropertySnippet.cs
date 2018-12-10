public static AdminShell.Submodel CreateSubmodelDatasheetSingleItems(
    AdminShell.UriIdentifierRepository repo, AdminShell.AdministrationShellEnv aasenv)
{
    // SUB MODEL
    var sub1 = AdminShell.Submodel.CreateNew("URI", repo.CreateOneTimeId());
    sub1.idShort = "Datatsheet";
    aasenv.submodels.submodels.Add(sub1);
    sub1.semanticId.keys.key.Add(AdminShell.Key.CreateNew(
        type:   "Submodel", 
        local:  false, 
        idType: "URI", 
        value:  "http://smart.festo.com/id/type/submodel/festodatasheet/1/1"));

    // eClass product group: 19-15-07-01 USB stick              
    // siehe: http://www.eclasscontent.com/?id=19150701&version=10_1&language=de&action=det

    // CONCEPT: Weight by Michael Hoffmeister                   // Schreiben Sie hier Ihren Namen
    using (var cd = AdminShell.ConceptDescription.CreateNew(
        idType:"IRDI",                                          // immer IRDI für eCl@ss
        id:"0173-1#02-AAS627#001"))                             // die ID des Merkmales bei eCl@ss
    {
        aasenv.conceptDescriptions.conceptDescriptions.Add(cd);
        cd.SetIEC61360Spec(
            preferredNames: new string[] { 
                "DE", "Gewicht der Artikeleinzelverpackung",    // wechseln Sie die Sprache bei eCl@ss 
                "EN", "Weight of the individual packaging" },   // um die Sprach-Texte aufzufinden
            shortName: "Weight",                                // kurzer, sprechender Name
            unit: "g",                                          // Gewicht als SI Einheit ohne Klammern
            valueFormat: "REAL_MEASURE",                        // REAL oder INT_MEASURE oder STRING
            definition: new string[] { "DE", "Masse der Einzelverpackung eines Artikels",
            "EN", "Mass of the individual packaging of an article" }
        );

        var p = AdminShell.Property.CreateNew(cd.GetShortName(), "PARAMETER", 
                    AdminShell.Key.GetFromRef(cd.GetReference()));
        sub1.Add(p);
        p.valueType = "double";                                 // hier den Datentypen im XSD-Format
        p.value = "23";                                         // hier den Wert; immer als String mit
    }                                                           // doppelten Anfuehrungszeichen

    // Nice
    return sub1;
}
