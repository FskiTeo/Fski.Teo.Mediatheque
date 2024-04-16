namespace Mediatheque.Core
{
    public interface INotationService
    {
        /// <summary>
        /// Fournit la note de l'album selon des avis d'internautes
        /// </summary>
        /// <param name="nomAlbum">nom de l'album</param>
        /// <returns>une note entre 1 et 5</returns>
        /// <example>GetNoteAlbum("Smash") -> 5</example>
        /// <example>GetNoteAlbum("Spice world") -> 1</example>
        int GetNoteAlbum(string nomAlbum);

    }
}
