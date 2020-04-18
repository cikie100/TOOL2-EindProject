using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tool2.Klas;

namespace Tool2.Databeheer
{
    public class Databeheerder
    //Hierin lees ik al de zelfgemaakte data bestanden in
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

        #endregion

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
    }
    
}