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
    
    public partial class personne_login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personne_login()
        {
            this.temoignage = new HashSet<temoignage>();
            this.token = new HashSet<token>();
        }
    
        public int id { get; set; }
        public string login { get; set; }
        public string mp { get; set; }
        public Nullable<System.DateTime> derniere_connexion { get; set; }
        public int nb_tentative_erreur { get; set; }
    
        public virtual personne personne { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<temoignage> temoignage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<token> token { get; set; }
    }
}
