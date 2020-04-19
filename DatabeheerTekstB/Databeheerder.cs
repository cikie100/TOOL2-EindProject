using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tool2.Klas;

namespace Tool2.Databeheer
{
    public class Databeheerder
    //Hierin lees ik al de zelfgemaakte data bestanden in en geef ik hun terug als List<Objects>
    {

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
        #endregion

        // ProvincieBestand.txt(provincieID;Provnaam;taalcode;(gemeenteId))
        //geeft Graaf lijst terug
        public List<Graaf> getGraafenLijst()
        {
            List<Graaf> graafLijst = new List<Graaf>();

            List<string> GraafInfoLIJN;

            using (FileStream fs = File.Open(@"..\..\..\..\dataVanTool1\GraafBestand.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sreader = new StreamReader(bs))
            {
                string input = null;

                //sla de eerste regel over
                sreader.ReadLine();

                Graaf dummyGraaf;
                while ((input = sreader.ReadLine()) != null)
                {
                    GraafInfoLIJN = new List<string>();
                    string woord = input;
                    string[] wholeLine = woord.Split('>').Where(val => val != "").ToArray(); ;

                    string x = wholeLine[0];
                    string[] wholeLine1 = x.Replace(")]) ", ")]); ").Replace(")])<", ")]); ").Split(';');

                    wholeLine1[0] = wholeLine1[0].Replace("graafID", "");
                    //maak graaf aan met id
                    dummyGraaf = new Graaf(Convert.ToInt32(wholeLine1[0]));
                    //verwijder de id [0] van de te bewerken data (want de id werd al gebruikt)
                    wholeLine1 = wholeLine1.Skip(1).ToArray();
                    List<Knoop> knopen = new List<Knoop>();
                    // List<String> wholeLineList = wholeLine1.ToList();

                    List<String> knooptekst = new List<string>();
                    while (wholeLine1.Count() != 0)
                    {


                        if (wholeLine1[0] == " ")
                        {
                            foreach (Knoop knp in knopen)
                            {
                                dummyGraaf.map.Add(knp, knp.segmenten);
                            }

                            graafLijst.Add(dummyGraaf);
                            wholeLine1 = wholeLine1.Skip(1).ToArray();
                        }

                        for (int i = 0; i < wholeLine1.Count(); i++)
                        {

                          



                            if (wholeLine1[0].StartsWith(" KnoopId"))
                            {

                                knooptekst = wholeLine1.Take(3).ToList();
                                knooptekst[0] = knooptekst[0].Replace(" KnoopId,puntx,punty: ", "");
                                knopen.Add(new Knoop(Convert.ToInt32(knooptekst[0]), new Punt(Convert.ToDouble(knooptekst[1]), Convert.ToDouble(knooptekst[2]))));
                                wholeLine1 = wholeLine1.Skip(3).ToArray();
                            }
                            if (wholeLine1[0].StartsWith("( segmentID")||
                                wholeLine1[0].StartsWith(" segmentID,be")

                                )
                            {
                                List<String> segmentTekst = wholeLine1.Take(3).ToList();
                                segmentTekst[0] = segmentTekst[0].Replace("( segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                segmentTekst[0] = segmentTekst[0].Replace(" segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                Segment dummySeg = new Segment(Convert.ToInt32(segmentTekst[0]), Convert.ToInt32(segmentTekst[1]), Convert.ToInt32(segmentTekst[2]));
                                wholeLine1 = wholeLine1.Skip(3).ToArray();
                                string[] punten = wholeLine1[0].Replace(";[(", "").Split(']');

                                List<Punt> puntenLijst = new List<Punt>();

                                int empt = 0;
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
                                if (punten.Length > 0)
                                {
                                    if (punten[1] != ")")
                                    {
                                        punten[1] = punten[1].Replace(") segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                    
                                    empt = Convert.ToInt32(punten[1]);
                                    };
                                }
                                if (empt != 0)
                                {
                                    knopen.Where(k => k.knoopID == Convert.ToInt32(knooptekst[0])).First().segmenten.Add(new Segment(empt, Convert.ToInt32(wholeLine1[0]), Convert.ToInt32(wholeLine1[1])));
                                    wholeLine1 = wholeLine1.Skip(2).ToArray();


                                    Boolean segm = false;
                                    Boolean knoop = false;
                                    punten = wholeLine1[0].Replace(";[(", "").Split(']');

                                    puntenLijst = new List<Punt>();

                                    empt = 0;
                                    punten[0] = punten[0].Replace("[(", "").Replace("(", "");
                                    puntenApart = punten[0].Split(')').ToList();

                                   
                                    puntenApart.ForEach(lijn =>
                                    {
                                        if (lijn != "")
                                        {
                                            String[] lx = lijn.Split(",");
                                            dummySeg.punten_verticles.Add(new Punt(Convert.ToDouble(lx[0]), Convert.ToDouble(lx[1])));
                                            knopen.Where(k => k.knoopID == Convert.ToInt32(knooptekst[0])).First().segmenten.Add(dummySeg);
                                        }
                                    });

                                 
                                    wholeLine1 = wholeLine1.Skip(1).ToArray();

                                    if (punten.Length > 0)
                                    {
                                        if (punten[1].StartsWith(") segmentID,begi"))
                                        {
                                            punten[1] = punten[1].Replace(") segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                            empt = Convert.ToInt32(punten[1]);
                                            segm = true;
                                        }
                                        else if (punten[1].StartsWith(") KnoopId,puntx,punty:"))
                                        {
                                            punten[1] = punten[1].Replace(") KnoopId,puntx,punty: ", "");
                                            empt = Convert.ToInt32(punten[1]);
                                            knooptekst[0] = Convert.ToString(empt);
                                            knoop = true;
                                        }
                                    }
                                    if (empt != 0)
                                    {
                                        if (segm)
                                        {
                                            knopen.Where(k => k.knoopID == Convert.ToInt32(knooptekst[0])).First().segmenten.Add(new Segment(empt, Convert.ToInt32(wholeLine1[0]), Convert.ToInt32(wholeLine1[1])));
                                            wholeLine1 = wholeLine1.Skip(2).ToArray();
                                            segm = false;
                                        }
                                        if (knoop)
                                        {
                                            knopen.Add(new Knoop(Convert.ToInt32(knooptekst[0]), new Punt(Convert.ToDouble(wholeLine1[0]), Convert.ToDouble(wholeLine1[1]))));
                                            wholeLine1 = wholeLine1.Skip(2).ToArray();
                                            knoop = false;
                                        }
                                    }

                                }

                            }



                        }
                    }

                }


                return graafLijst;
            }
        }
        //probleematisch 
        public List<Graaf> getGraafLijst()
        {
            List<Graaf> graafLijst = new List<Graaf>();

            List<string> GraafInfoLIJN;

            using (FileStream fs = File.Open(@"..\..\..\..\dataVanTool1\GraafTest.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sreader = new StreamReader(bs))
            {
                string input = null;

                //sla de eerste regel over
                sreader.ReadLine();
                List<Knoop> knopen = new List<Knoop>();
                Graaf dummyGraaf;
                while ((input = sreader.ReadLine()) != null)
                {
                    GraafInfoLIJN = new List<string>();
                    string woord = input;
                    string[] wholeLine = woord.Split('>').Where(val => val != "").ToArray(); ;

                    string x = wholeLine[0];
                    string[] wholeLine1 = x.Split(';');

                    wholeLine1[0] = wholeLine1[0].Replace("graafID", "");
                    //maak graaf aan met id
                    dummyGraaf = new Graaf(Convert.ToInt32(wholeLine1[0]));
                    //verwijder de id [0] van de te bewerken data (want de id werd al gebruikt)
                    wholeLine1 = wholeLine1.Skip(1).ToArray();

                    // List<String> wholeLineList = wholeLine1.ToList();

                    while (wholeLine1.Count() > 0)
                    {
                        List<String> knooptekst = new List<string>();
                        for (int i = 0; i < wholeLine1.Count(); i++)
                        {
                            if (wholeLine1[i].StartsWith(" KnoopId"))
                            {

                                knooptekst = wholeLine1.Take(3).ToList();
                                knooptekst[0] = knooptekst[0].Replace(" KnoopId,puntx,punty: ", "");
                                knopen.Add(new Knoop(Convert.ToInt32(knooptekst[0]), new Punt(Convert.ToDouble(knooptekst[1]), Convert.ToDouble(knooptekst[2]))));
                                wholeLine1 = wholeLine1.Skip(3).ToArray();
                            }
                            if (wholeLine1[i].StartsWith("( segmentID"))
                            {
                                List<String> segmentTekst = wholeLine1.Take(3).ToList();
                                segmentTekst[0] = segmentTekst[0].Replace("( segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                Segment dummySeg = new Segment(Convert.ToInt32(segmentTekst[0]), Convert.ToInt32(segmentTekst[1]), Convert.ToInt32(segmentTekst[2]));
                                wholeLine1 = wholeLine1.Skip(3).ToArray();
                                string[] punten = wholeLine1[0].Replace(";[(", "").Split(']');

                                List<Punt> puntenLijst = new List<Punt>();

                                int empt = 0;
                                punten[0] = punten[0].Replace("[(", "").Replace("(", "");
                                List<String> puntenApart = punten[0].Split(')').ToList();

                                puntenApart.ForEach(lijn =>
                                {
                                    if (lijn != "")
                                    {
                                        String[] lx = lijn.Split(",");
                                        dummySeg.punten_verticles.Add(new Punt(Convert.ToDouble(lx[0]), Convert.ToDouble(lx[1])));
                                        knopen.Where(k => k.knoopID == Convert.ToInt32(knooptekst[0])).First().segmenten.Add(dummySeg);
                                    }
                                });
                                wholeLine1 = wholeLine1.Skip(1).ToArray();
                                if (punten.Length > 0)
                                {
                                    punten[1] = punten[1].Replace(") segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                    empt = Convert.ToInt32(punten[1]);
                                }
                                if (empt != 0)
                                {
                                    knopen.Where(k => k.knoopID == Convert.ToInt32(knooptekst[0])).First().segmenten.Add(new Segment(empt, Convert.ToInt32(wholeLine1[0]), Convert.ToInt32(wholeLine1[1])));
                                    wholeLine1 = wholeLine1.Skip(2).ToArray();


                                    Boolean segm = false;
                                    Boolean knoop = false;
                                    punten = wholeLine1[0].Replace(";[(", "").Split(']');

                                    puntenLijst = new List<Punt>();

                                    empt = 0;
                                    punten[0] = punten[0].Replace("[(", "").Replace("(", "");
                                    puntenApart = punten[0].Split(')').ToList();

                                    puntenApart.ForEach(lijn =>
                                    {
                                        if (lijn != "")
                                        {
                                            String[] lx = lijn.Split(",");
                                            dummySeg.punten_verticles.Add(new Punt(Convert.ToDouble(lx[0]), Convert.ToDouble(lx[1])));
                                            knopen.Where(k => k.knoopID == Convert.ToInt32(knooptekst[0])).First().segmenten.Add(dummySeg);
                                        }
                                    });

                                    if (wholeLine1.Length == 1)
                                    {
                                        foreach (Knoop knp in knopen)
                                        {
                                            dummyGraaf.map.Add(knp, knp.segmenten);
                                        }

                                        graafLijst.Add(dummyGraaf);
                                    }
                                    wholeLine1 = wholeLine1.Skip(1).ToArray();

                                    if (punten.Length > 0)
                                    {
                                        if (punten[1].StartsWith(") segmentID,begi"))
                                        {
                                            punten[1] = punten[1].Replace(") segmentID,beginknoop.knoopID,eindknoop.knoopID: ", "");
                                            empt = Convert.ToInt32(punten[1]);
                                            segm = true;
                                        }
                                        else if (punten[1].StartsWith(") KnoopId,puntx,punty:"))
                                        {
                                            punten[1] = punten[1].Replace(") KnoopId,puntx,punty: ", "");
                                            empt = Convert.ToInt32(punten[1]);
                                            knooptekst[0] = Convert.ToString(empt);
                                            knoop = true;
                                        }
                                    }
                                    if (empt != 0)
                                    {
                                        if (segm)
                                        {
                                            knopen.Where(k => k.knoopID == Convert.ToInt32(knooptekst[0])).First().segmenten.Add(new Segment(empt, Convert.ToInt32(wholeLine1[0]), Convert.ToInt32(wholeLine1[1])));
                                            wholeLine1 = wholeLine1.Skip(2).ToArray();
                                            segm = false;
                                        }
                                        if (knoop)
                                        {
                                            knopen.Add(new Knoop(Convert.ToInt32(knooptekst[0]), new Punt(Convert.ToDouble(wholeLine1[0]), Convert.ToDouble(wholeLine1[1]))));
                                            wholeLine1 = wholeLine1.Skip(2).ToArray();
                                            knoop = false;
                                        }
                                    }

                                }

                            }



                        }
                    }

                }


                return graafLijst;
            }
        }
    }
    
}