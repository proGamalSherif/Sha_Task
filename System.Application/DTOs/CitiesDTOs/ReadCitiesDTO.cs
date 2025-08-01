using System.Application.DTOs.BranchesDTOs;

namespace System.Application.DTOs.CitiesDTOs
{
    public class ReadCitiesDTO : BaseCitiesDTO
    {
        public int ID { get; set; }
        public IList<ReadBranchDTO> Branches { get; set; }
    }
}
