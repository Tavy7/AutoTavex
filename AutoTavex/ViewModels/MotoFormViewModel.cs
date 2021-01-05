using AutoTavex.Models;

namespace AutoTavex.ViewModels
{
    public class MotoFormViewModel
    { 
    public string Title { get; set; }
    public Moto Moto { get; set; }

    public MotoFormViewModel(int id = 0)
    {
        Title = CarFormViewmodel.Add;
        Moto = new Moto
        {
            Id = id
        };
    }
}
}