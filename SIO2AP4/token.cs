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
    
    public partial class token
    {
        public int id { get; set; }
        public int id_login { get; set; }
        public System.DateTime date { get; set; }
        public string jeton { get; set; }
    
        public virtual personne_login personne_login { get; set; }
    }
}
