using System.Collections.Generic;
using E_Players37_AspNetCore.Models;

namespace E_Players37_AspNetCore.Interfaces
{
    public interface INoticias 
    {
        // Create
        void Create(Noticias n);
        // Read
        List<Equipe> ReadAll();
        // Update
        void Update(Noticias n);
        // Delete
        void Delete(int idNoticias);
    }
}