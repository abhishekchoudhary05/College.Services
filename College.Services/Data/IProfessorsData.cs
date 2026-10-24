using College.Services.Entities;
using System;
using System.Collections.Generic;

namespace College.Services.Data
{
    public interface IProfessorsData
    {
        IEnumerable<Professor> GetProfessors();
        Professor GetProfessorById(Guid id);
        Professor AddProfessor(Professor professor);
        Professor UpdateProfessor(Professor professor);
        bool DeleteProfessorById(Guid id);
    }
}
