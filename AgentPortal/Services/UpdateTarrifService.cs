using System.Collections.Generic;
using PortalLibrary.Models;

namespace AgentPortal.Services
{
    public class UpdateTarrifService : AgentLibraryService
    {
       public static List<Tarrif> GetTarrifPlan() 
       {
           List<Tarrif> tarrifList = new List<Tarrif>();
           tarrifList = service.GetAllTarrif();
           return tarrifList;
       }
    }
}