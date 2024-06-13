using AracTamirTakipWebApi.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Isemri
{
    [Key]
    public int IsemriId { get; set; }

    [Required]
    public int MusteriId { get; set; }

    [Required]
    public int ModelId { get; set; }

    public string Plaka { get; set; }

    public string SaseNo { get; set; }

    [Required]
    public int AracKm { get; set; }

    [Required]
    public int ModelYil { get; set; }

    public string YakitTuru { get; set; }

    [Required]
    public DateTime GelisTarihi { get; set; }

    public string GelisSebebi { get; set; }

    [Required]
    public bool Kapali { get; set; }

    public string OdemeSekli { get; set; }

    public string Aciklama { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal AlinanUcret { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? KapatmaTarihi { get; set; }

    // İlişkili tabloların navigasyon özellikleri
    [ForeignKey("ModelId")]
    public virtual Model Model { get; set; }

    [ForeignKey("MusteriId")]
    public virtual Musteri Musteri { get; set; }
}
