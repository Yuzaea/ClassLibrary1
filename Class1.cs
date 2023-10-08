namespace ClassLibrary1
{
    public class Book
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }

        public Book(int id, int price, string title)
        {
            Id = id;
            Price = price;
            Title = title;
        }

        public override string ToString()
        {
            return $"ID{Id} Title{Title} Price{Price}";
        }

        public void ValidateTitle(string title)
        {
            if (Title == null|| title.Length < 3) {
                throw new ArgumentException("Title skal vøre mindst 3");
                    }
        }

        public void ValdiDatePrice(int price)
        {
            if (Price <=0 || Price > 1200) {
                throw new ArgumentException("pris skal være mellem 0 og 1200");
            }
        }
    }
}