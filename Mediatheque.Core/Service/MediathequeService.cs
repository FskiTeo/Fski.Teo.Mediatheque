using Mediatheque.Core.Model;

namespace Mediatheque.Core.Service
{
    public class MediathequeService
    {
        private List<ObjetDePret> _fondDeCommerce = new List<ObjetDePret>();
        private INotationService _notationService;

        public MediathequeService(INotationService notationService)
        {
            _notationService = notationService;
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
