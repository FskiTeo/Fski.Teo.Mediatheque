using Mediatheque.Core.DAL;
using Mediatheque.Core.Model;
using Mediatheque.Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Mediatheque.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDBContext applicationDBContext = new ApplicationDBContext();

            MediathequeService mediatheque = new MediathequeService(null, applicationDBContext);

            CD cd1 = mediatheque.AddCd("Polak", "PLK");
            CD cd2 = mediatheque.AddCd("Chambre 140", "PLK");
            CD cd3 = mediatheque.AddCd("Numb", "Linkin Park");
            CD cd4 = mediatheque.AddCd("Blurryfacee", "Twenty One Pilots");

            Etagere etagere1 = new Etagere();
            etagere1.Emplacement = "Au fond de la salle";

            etagere1.listeDeCDs.Add(cd1);
            etagere1.listeDeCDs.Add(cd3);

            applicationDBContext.Etagere.Add(etagere1);
            applicationDBContext.SaveChanges();

            Console.WriteLine("Voici la liste des CDs que nous proposons : ");
            List<CD> cdList = mediatheque.GetCDs();
            for(int i = 0; i < cdList.Count; i++)
            {
                Console.WriteLine(cdList[i].ToString());
            }
            

            Console.WriteLine("Oups, une faute d'orthographe s'est glissée dans le titre du cd 4. Nous l'avons corrigée.");
            mediatheque.EditCd(cd4.Id, "Blurryface");
            Console.WriteLine(cd4.ToString());



            Console.WriteLine("Nous cherchons le cd qui a pour ID 11. Le voici ! ");
            CD cdFoundById = mediatheque.GetCdById(11);
            Console.WriteLine(cdFoundById.ToString());


            
            Console.WriteLine("Mince, le CD3 est cassé, il faut l'enlever");
            mediatheque.DeleteCD(cd3.Id);
            List<CD> cdList2 = mediatheque.GetCDs();
            Console.WriteLine("Voici la liste actualisée : ");
            for (int i = 0; i < cdList2.Count; i++)
            {
                Console.WriteLine(cdList2[i].ToString());
            }



            Console.WriteLine("Qu'est-ce que PLK chante bien ! Peut-on voir ses CDs ?");
            List<CD> cdsDuMemeGroupe = mediatheque.GetCdsByGroupe("PLK");
            for (int i = 0; i < cdsDuMemeGroupe.Count; i++)
            {
                Console.WriteLine(cdsDuMemeGroupe[i].ToString());
            }

        }
    }
}
