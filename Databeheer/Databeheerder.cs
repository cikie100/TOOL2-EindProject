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
                    provincies.Add(new Provincie(ProvInfo[0], ProvInfo[1], ProvInfo[2]));
                    for (int i = 3; i < ProvInfo.Count; i++)
                    {
                        if(ProvInfo[i] != "") { 
                        provincies.Where(p => p.provincieId.Equals(ProvInfo[0])).FirstOrDefault().gemeenteIdStrings.Add(ProvInfo[i]);
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
                    gemeentes.Add(new Gemeente(GemInfo[0], GemInfo[1]));
                    for (int i = 2; i < GemInfo.Count; i++)
                    {
                        if (GemInfo[i] != "")
                        {
                            gemeentes.Where(g => g.gemeenteId.Equals(GemInfo[0])).FirstOrDefault().stratenNaamId.Add(GemInfo[i]);
                        }
                    }
                }
                return gemeentes;
            }
        }

        #endregion



    }
}