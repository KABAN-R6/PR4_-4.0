//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PR4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotell()
        {
            this.Permit = new HashSet<Permit>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Service { get; set; }
    
        public virtual Servicce Servicce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permit> Permit { get; set; }
    }
}
