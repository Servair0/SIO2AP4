//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIO2AP4
{
    using System;
    using System.Collections.Generic;
    
    public partial class soins
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public soins()
        {
            this.soins_visite = new HashSet<soins_visite>();
        }
    
        public int id_categ_soins { get; set; }
        public int id_type_soins { get; set; }
        public int id { get; set; }
        public string libel { get; set; }
        public string description { get; set; }
        public float coefficient { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual type_soins type_soins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<soins_visite> soins_visite { get; set; }
    }
}
