namespace System.Application.DTOs.CashierDTOs
{
    public class ReadCashierDTO : BaseCashierDTO
    {
        public int ID { get; set; }
        public string BranchName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
