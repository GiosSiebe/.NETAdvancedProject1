namespace WineCode
{
    public class Wine
    {
        public int WineID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TasteProfile { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public Country Country { get; set; }
        public List<Category> Categories { get; set; }
        public Kind Kind { get; set; }
        public List<Recipe>? Recipes { get; set; }
    }
}
