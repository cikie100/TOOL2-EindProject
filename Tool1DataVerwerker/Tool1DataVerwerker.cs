using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tool2.Klas;

namespace Tool2.Databeheer
{
    public class Tool1DataVerwerker
    //Hierin lees ik al de zelfgemaakte data bestanden in en geef ik hun terug als List<Objects>
    {
        public List<Knoop> getalleknopen;
        public List<Segment> getallesegmenten;
        #region WORKS

        // ProvincieBestand.txt (provincieID;Provnaam;taalcode;(gemeenteId))
        //geeft provincie lijst terug
        public List<Provincie> getProvincies()
        {
            List<Provincie> provincies = new List<Provincie>();

            List<string> ProvInfo;

            using (FileStream fs = File.Open(@"..\..\..\..\dataVanTool1\ProvincieBestand.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sreader = new StreamReader(bs))
            {
                string input = null;

                //sla de eerste regel over
                sreader.ReadLine();
                while ((input = sreader.ReadLine()) != null)
                {
                    ProvInfo = new List<string>();
                    string woord = input;
                    string[] words = woord.Replace(";(", ";")
                        .Trim(new Char[] { ')' })
                        .Split(';');
                    for
                    (int i = 0; i < words.Count(); i++) //loops through each line of the array
                    {
                        ProvInfo.Add(words[i]);
                    }
                    provincies.Add(new Provincie(Convert.ToInt32(ProvInfo[0]), ProvInfo[1], ProvInfo[2]));
                    for (int i = 3; i < ProvInfo.Count; i++)
                    {
                        if (ProvInfo[i] != "")
                        {
                            provincies.Where(p => p.ProvincieId.Equals(Convert.ToInt32(ProvInfo[0]))).FirstOrDefault().GemeenteIdStrings.Add(Convert.ToInt32(ProvInfo[i]));
                        }
                    }
                }

                // string[] ProvInfoTotal= ProvInfo""

                return provincies;
            }
        }

        // GemeenteBestand.txt (GemeenteId;Gemeente_naam;(StraatId))
        //geeft gemeente lijst terug
        public List<Gemeente> getGemeentes()
        {
            List<Gemeente> gemeentes = new List<Gemeente>();
            List<string> GemInfo;

            using (FileStream fs = File.Open(@"..\..\..\..\dataVanTool1\GemeenteBestand.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sreader = new StreamReader(bs))
            {
                string input = null;

                //sla de eerste regel over
                sreader.ReadLine();
                while ((input = sreader.ReadLine()) != null)
                {
                    GemInfo = new List<string>();
                    string woord = input;
                    string[] words = woord.Replace(";(", ";")
                        .Trim(new Char[] { ')' })
                        .Split(';');

                    for
                    (int i = 0; i < words.Count(); i++) //loops through each line of the array
                    {
                        GemInfo.Add(words[i]);
                    }
                    gemeentes.Add(new Gemeente(Convert.ToInt32(GemInfo[0]), GemInfo[1]));
                    for (int i = 2; i < GemInfo.Count; i++)
                    {
                        if (GemInfo[i] != "")
                        {
                            gemeentes.Where(g => g.GemeenteId.Equals(Convert.ToInt32(GemInfo[0]))).FirstOrDefault().StratenNaamIdLijst.Add(Convert.ToInt32(GemInfo[i]));
                        }
                    }
                }
                return gemeentes;
            }
        }

        // StraatBestand.txt (straatId;Straatnaam;lengte;graafID)
        //geeft gemeente lijst terug
        public List<Straat> getStraten()
        {
            List<Straat> straten = new List<Straat>();
            List<string> StraatInfo;

            using (FileStream fs = File.Open(@"..\..\..\..\dataVanTool1\StraatBestand.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sreader = new StreamReader(bs))
            {
                string input = null;

                //sla de eerste regel over
                sreader.ReadLine();
                while ((input = sreader.ReadLine()) != null)
                {
                    StraatInfo = new List<string>();
                    string woord = input;
                    string[] words = woord.Split(';');

                    //loops through each line of the array
                    //straatId;Straatnaam;lengte;graafID

                    straten.Add(new Straat(Convert.ToInt32(words[0]), words[1], Math.Round(Convert.ToDouble(words[2])), Convert.ToInt32(words[3])));
                }
                return straten;
            }
        }

        // GraafBestand.txt(>GraafId; KnoopId; knoop x punt; knoop y punt; (segmID;segm.beginknoop.knoopID;segm.eindknoop.knoopID)[(punt.x,punt.y)(punt.x,punt.y)...]<)
        //geeft Graaf lijst terug
        public List<Graaf> getGraafenLijst()
        {
            //deze code is niet bepaald mooi, maar het werkt, en ik ben er wel beetje trots op :)
            getalleknopen = new List<Knoop>();
            getallesegmenten = new List<Segment>();

            List<Graaf> graafLijst = new List<Graaf>();
            List<string> GraafInfoLIJN;

            using (FileStream fs = File.Open(@"..\..\..\..\dataVanTool1\GraafBestand.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sreader = new StreamReader(bs))
            {
                string input = null;
                //sla de eerste regel over.
                sreader.ReadLine();

                Graaf dummyGraaf;
                while ((input = sreader.ReadLine()) != null)
                {
                    GraafInfoLIJN = new List<string>();
                    string woord = input;

                    //Splits het tekstbestand op per graaf sinds elke graaf begint met een '>' teken.
                    string[] wholeLine = woord.Split('>').Where(val => val != "").ToArray(); ;
                    string x = wholeLine[0];

                    //dit lijn vergemakelijkt het later om de tekst te manipuleren.
                    string[] wholeLine1 = x.Replace(")]) ", ")]); ").Replace(")])<", ")]); ").Split(';');

                    //doet bv. "graafID9" => "9".
                    wholeLine1[0] = wholeLine1[0].Replace("graafID", "");

                    //maak graaf aan met id, gaat hij voor elke graaf doen.
                    dummyGraaf = new Graaf(Convert.ToInt32(wholeLine1[0]));

                    //verwijder de id [0] van de te bewerken data (want de id werd al gebruikt)
                    wholeLine1 = wholeLine1.Skip(1).ToArray();
                    //maakt knopenLijst opnieuw leeg aan, hier komen al de knopen voor de graaf.
                    List<Knoop> knopen = new List<Knoop>();

                    //gaat meestal tijdelijk een knoopid, x, y punten bijhouden
                    List<String> knooptekst = new List<string>();

                    //overloop de graaf tot zijn tekst opgebruikt is
                    //mijn manier van werken is de lijst steeds te verminderen door lijnen te verwijderen eens ik het gebruikt heb.
                    while (wholeLine1.Count() != 0)
                    {
                        //graaf tekst is op gebruikt? voeg graaf toe aan de lijst die je gaat terug geven.
                        if (wholeLine1[0] == " ")
                        {
                            foreach (Knoop knp in knopen) { dummyGraaf.map.Add(knp, knp.segmenten);
                                //nodig gehad om dbo.Knoop aan te maken
                                //getalleknopen.Add(knp);
                                foreach (Segment seg in knp.segmenten)
                                {
                                    getallesegmenten.Add(seg);
                                }
                                
                            }
                            graafLijst.Add(dummyGraaf);
                            wholeLine1 = wholeLine1.Skip(1).ToArray();
                        }

                        for (int i = 0; i < wholeLine1.Count(); i++)
                        {   //is de volgende info een knoop?
                            if (wholeLine1[0].StartsWith(" KnoopId"))
                            {
                                knooptekst = wholeLine1.Take(3).ToList();
                                knooptekst[0] = knooptekst[0].Replace(" KnoopId,puntx,punty: ", "");
                                knopen.Add(new Knoop(Convert.ToInt32(knooptekst[0]), new Punt(Convert.ToDouble(knooptekst[1]), Convert.ToDouble(knooptekst[2]))));
                                wholeLine1 = wholeLine1.Skip(3).ToArray();
                            }
                            //is de volgende info een segment?
                            if (wholeLine1[0].StartsWith("( segmentID") ||
                                wholeLine1[0].StartsWith(" segmentID,be")
                                                                )
                            {
                                // neemt de segmentID,beginknoop.knoopID,eindknoop.knoopID van een knoop
                                List<String> segmentTekst = wholeLine1.Take(3).ToList();
                                segmentTekst[0] = segmentTekst[0].Replace("( segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                segmentTekst[0] = segmentTekst[0].Replace(" segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");

                                // maakt een segment van die (segmentID,beginknoop.knoopID,eindknoop.knoopID van een knoop)
                                Segment dummySeg = new Segment(Convert.ToInt32(segmentTekst[0]), Convert.ToInt32(segmentTekst[1]), Convert.ToInt32(segmentTekst[2]));

                                // verwijder de 3 gebruikte lijnen
                                wholeLine1 = wholeLine1.Skip(3).ToArray();

                                //nu de punten van de segment hierboven ophalen
                                string[] punten = wholeLine1[0].Replace(";[(", "").Split(']');
                                List<Punt> puntenLijst = new List<Punt>();

                                punten[0] = punten[0].Replace("[(", "").Replace("(", "".Replace(")", ""));
                                List<String> puntenApart = punten[0].Split(')').ToList();

                                puntenApart.ForEach(lijn =>
                                {
                                    if (lijn != "")
                                    {
                                        String[] lx = lijn.Split(",");
                                        dummySeg.punten_verticles.Add(new Punt(Convert.ToDouble(lx[0]), Convert.ToDouble(lx[1])));
                                    }
                                }); knopen.Where(k => k.knoopID == Convert.ToInt32(knooptekst[0])).First().segmenten.Add(dummySeg);

                                wholeLine1 = wholeLine1.Skip(1).ToArray();

                                //punten heeft altijd een Lijst<Punt> op punten[0]
                                //maar soms neemt die de volgende segm mee en die komt dan naar punten[1]
                                //enkel als de knoop meerdere segm heeft
                                if (punten.Length > 0)
                                {
                                    if (punten[1] != ")")
                                    {
                                        punten[1] = punten[1].Replace(") segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                    };
                                }
                            }
                        }
                    }
                }
                return graafLijst;
            }
        }

        #endregion WORKS

        
    }
}