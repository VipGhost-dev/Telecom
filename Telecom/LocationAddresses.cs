//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Telecom
{
    using System;
    using System.Collections.Generic;
    
    public partial class LocationAddresses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LocationAddresses()
        {
            this.Subscribers = new HashSet<Subscribers>();
        }
    
        public string ID { get; set; }
        public string PrefixCode { get; set; }
        public int IDDistrict { get; set; }
        public int IDCity { get; set; }
        public Nullable<int> IDStreet { get; set; }
        public Nullable<int> NumberHouse { get; set; }
    
        public virtual Citys Citys { get; set; }
        public virtual Districts Districts { get; set; }
        public virtual Streets Streets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribers> Subscribers { get; set; }
    }
}
