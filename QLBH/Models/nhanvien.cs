namespace QLBH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
    using System.Data.Entity.Spatial;

    [Table("nhanvien")]
    public partial class nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nhanvien()
        {
            phieugiaohangs = new HashSet<phieugiaohang>();
        }

        [Key]
        [StringLength(50), DisplayName("Ma nhan vien")]
        [Required(ErrorMessage ="Xin nhap ma nhan vien")]
        public string manv { get; set; }

        [StringLength(50), DisplayName("Ten nhan vien")]
        [Required(ErrorMessage = "Xin nhap ten nhan vien")]
        public string tennv { get; set; }
        [DisplayName("Ngay sinh"),DisplayFormat(DataFormatString ="{0:d}")]
        [Required(ErrorMessage = "Xin nhap ngay sinh")]
        public DateTime? ngaysinh { get; set; }
        [DisplayName("Phai")]
        public bool? phai { get; set; }

        [StringLength(50), DisplayName("Dia chi")]
        [Required(ErrorMessage = "Xin nhap dia chi")]
        public string diachi { get; set; }

        [StringLength(50), DisplayName("Password")]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieugiaohang> phieugiaohangs { get; set; }
    }
}
