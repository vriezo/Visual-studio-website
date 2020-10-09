using System;

namespace SchoolTemplate.Database
{
  public class Festival
  {
    public int Id { get; set; }
    
    public string Naam { get; set; }

    /// <summary>
    /// Gebruik altijd decimal voor geldzaken. Dit doe je om te voorkomen dat er afrondingsfouten optreden
    /// </summary>
    public Decimal Prijs { get; set; }

    public string Plaats { get; set; }

    public string Beschrijving { get; set; } 

    public string ImgLogo { get; set; }

  }
}
