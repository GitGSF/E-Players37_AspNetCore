using System.Collections.Generic;
using E_Players37_AspNetCore.Models;

namespace E_Players37_AspNetCore.Interfaces
{
    public interface IEquipe
    {
        // Create
        void Create(Equipe e);
        // Read
        List<Equipe> ReadAll();
        // Update
        void Update(Equipe e);
        // Delete
        void Delete(int idEquipe);
    }
}