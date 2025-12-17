namespace TechZone.Web.ViewModels.Shop
{
    using System.ComponentModel.DataAnnotations;

    public class ProductSearchQueryModel
    {
        // По коя страница сме (за странициране по-късно)
        public int CurrentPage { get; set; } = 1;

        // Какво е написал потребителя в търсачката
        public string SearchTerm { get; set; }

        // Филтър по Марка
        public string Brand { get; set; }

        // Филтър по Цена
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // Сортиране (Цена възх., Цена низх., Най-нови)
        public int Sorting { get; set; }

        // --- СПЕЦИФИЧНИ ФИЛТРИ (Ще ги ползваме по-късно) ---
        // Примерно: Ако сме в RAM категория -> колко GB
        public int? MemorySize { get; set; }
    }
}