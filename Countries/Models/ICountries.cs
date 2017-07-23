namespace Countries.Models
{
    public interface ICountries
    {
        Country[] Country { get; set; }

        int FindCountryIndexById(int id);
    }
}