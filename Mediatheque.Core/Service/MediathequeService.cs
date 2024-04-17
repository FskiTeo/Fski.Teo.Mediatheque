using Mediatheque.Core.DAL;
using Mediatheque.Core.Model;

namespace Mediatheque.Core.Service
{
    public class MediathequeService
    {
        private List<ObjetDePret> _fondDeCommerce = new List<ObjetDePret>();
        private INotationService _notationService;
        private ApplicationDBContext _applicationDBContext;

        public MediathequeService(INotationService notationService, ApplicationDBContext applicationDbContext)
        {
            _notationService = notationService;
            _applicationDBContext = applicationDbContext;
        }

        public List<CD> GetCDs()
        {
            return _applicationDBContext.CD.ToList();
        }

        public CD AddCd(string album, string groupe)
        {
            CD cd = new CD(album, groupe);
            this._applicationDBContext.CD.Add(cd);
            this._applicationDBContext.SaveChanges();
            return cd;
        }

        public CD GetCdById(int cdId)
        {
            return _applicationDBContext.CD.Find(cdId);
        }

        public List<CD> GetCdsByGroupe(string groupe)
        {
            //Ici aucune requête n'est encore faite
            IQueryable<CD> query = this._applicationDBContext.CD
                .Where(cd => cd.Groupe == groupe);

            //C'est ici que l'accès à la base est réalisée
            var cds = query.ToList();
            return query.ToList();
        }

        public void DeleteCD(int cdId)
        {
            var CdToDelete = this.GetCdById(cdId);
            this._applicationDBContext.CD.Remove(CdToDelete);
            this._applicationDBContext.SaveChanges();
        }

        public void EditCd(int cdId, string albumModified)
        {
            var cd = this.GetCdById(cdId);
            cd.TitreDeLObjet = albumModified;
            this._applicationDBContext.SaveChanges();
        }

        public void AddObjet(ObjetDePret objet)
        {
            _fondDeCommerce.Add(objet);
        }

        public int GetNombreObjet()
        {
            return _fondDeCommerce.Count;
        }

        public List<string> GetCDList()
        {
            List<string> list = new List<string>();

            for(int i = 0;  i < this.GetNombreObjet(); i += 1)
            {
                if (this._fondDeCommerce[i] is CD)
                {
                    list.Add(this._fondDeCommerce[i].TitreDeLObjet);
                }
            }

            if (list.Count == 0) {
                list.Add("Aucun objet dans cette liste");
            }

            return list;
        }
    }
}
