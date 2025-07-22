namespace C_Project3.Models
{
    public class BookBorrowModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime BookBorrowDate { get; set; }
        public int PriceCharged { get; set; }

        public BookInfoModel BookInfo { get; set; }

    }
}
