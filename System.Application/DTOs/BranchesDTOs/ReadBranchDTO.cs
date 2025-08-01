namespace System.Application.DTOs.BranchesDTOs
{
    public class ReadBranchDTO : BaseBranchDTO
    {
        public int Id { get; set; }
        public string CityName { get; set; }
    }
    public class BaseBranchDTO
    {
        public string BranchName { get; set; }
        public int CityID { get; set; }
    }
    public class BaseCitiesDTO 
    {
        public string CityName { get; set; }
    }
    public class ReadCitiesDTO : BaseCitiesDTO
    {
        public int ID { get; set; }
    }
}
