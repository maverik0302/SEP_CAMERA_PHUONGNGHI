//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEP_CAMERA_PHUONGNGHI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactForm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContactForm()
        {
            this.Contacts = new HashSet<Contact>();
        }
    
        public int ct_form_id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string emai { get; set; }
        public int ct_from_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
